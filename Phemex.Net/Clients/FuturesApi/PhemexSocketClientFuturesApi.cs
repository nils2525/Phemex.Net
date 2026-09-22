using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Sockets.Default;
using Microsoft.Extensions.Logging;
using Phemex.Net.Clients.MessageHandlers;
using Phemex.Net.Enums;
using Phemex.Net.Interfaces.Clients.FuturesApi;
using Phemex.Net.Objects.Models;
using Phemex.Net.Objects.Options;
using Phemex.Net.Objects.Sockets;
using Phemex.Net.Objects.Sockets.Subscriptions;
using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Phemex.Net.Clients.FuturesApi
{
    /// <summary>
    /// Client providing access to the Phemex Futures websocket Api
    /// </summary>
    internal partial class PhemexSocketClientFuturesApi : SocketApiClient<PhemexEnvironment, PhemexAuthenticationProvider, PhemexCredentials>, IPhemexSocketClientFuturesApi
    {
        #region Constructors
        internal PhemexSocketClientFuturesApi(PhemexSocketClient baseClient, ILoggerFactory? loggerFactory, PhemexSocketOptions options) :
            base(loggerFactory, PhemexExchange.Metadata.Id, options.Environment.SocketClientSpotAddress, options, options.FuturesOptions)
        {
            RateLimiter = PhemexExchange.RateLimiter.PhemexSocket;
            KeepAliveInterval = TimeSpan.Zero;
            RegisterPeriodicQuery(
                "Ping",
                TimeSpan.FromSeconds(15),
                q => new PhemexQuery(new PhemexSocketRequest
                {
                    Id = ExchangeHelpers.NextId(),
                    Method = "server.ping",
                    Parameters = []
                }, false) { RequestTimeout = TimeSpan.FromSeconds(15) },
                (connection, result) =>
                {
                    if (connection.Status is SocketStatus.Closing or SocketStatus.Closed or SocketStatus.Disposed)
                        return;

                    if (result.Error?.ErrorType == ErrorType.Timeout)
                    {
                        _logger.LogWarning("[Sckt {SocketId}] Ping response timeout, reconnecting", connection.SocketId);
                        _ = connection.TriggerReconnectAsync();
                    }
                });
        }
        #endregion

        #region Methods
        private static bool IsSuccessAcknowledgement(ReadOnlySpan<byte> data)
        {
            try
            {
                using var doc = JsonDocument.Parse(data.ToArray());
                var root = doc.RootElement;
                if (!root.TryGetProperty("id", out _))
                    return false;

                if (root.TryGetProperty("error", out var error)
                    && error.ValueKind is not JsonValueKind.Null and not JsonValueKind.Undefined)
                    return false;

                if (!root.TryGetProperty("result", out var result) || result.ValueKind != JsonValueKind.Object)
                    return false;

                return result.TryGetProperty("status", out var status)
                       && status.ValueKind == JsonValueKind.String
                       && string.Equals(status.GetString(), "success", StringComparison.OrdinalIgnoreCase);
            }
            catch (JsonException)
            {
                return false;
            }
        }

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(PhemexExchange._serializerContext);
        /// <inheritdoc />
        protected override bool ConnectionCanBeUsedFor(SocketConnection connection, string address, bool authenticated, string? topic = null)
            => base.ConnectionCanBeUsedFor(connection, address, authenticated, topic)
                && (topic != "orderbook_p" || !connection.Topics.Contains(topic));

        /// <inheritdoc />
        protected override bool HandleUnhandledMessage(SocketConnection connection, string typeIdentifier, ReadOnlySpan<byte> data)
        {
            if (IsSuccessAcknowledgement(data))
                return true;

            return base.HandleUnhandledMessage(connection, typeIdentifier, data);
        }

        /// <inheritdoc />
        protected override PhemexAuthenticationProvider CreateAuthenticationProvider(PhemexCredentials credentials)
            => new PhemexAuthenticationProvider(credentials);

        /// <inheritdoc />
        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType) => new PhemexSocketMessageHandler();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverDate = null)
            => PhemexExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverDate);

        /// <inheritdoc />
        public Task<WebSocketResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<PhemexFuturesAccountUpdate>> onMessage, CancellationToken ct = default)
        {
            var subscription = new PhemexSubscription<PhemexFuturesAccountUpdate>(_logger, "aop_p.subscribe", "aop_p.unsubscribe", [], "aop_p", null,
                (received, original, data) => onMessage(new DataEvent<PhemexFuturesAccountUpdate>(PhemexExchange.Metadata.Id, data, received, original)
                    .WithUpdateType(data.Type == PhemexUpdateType.Snapshot ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                    .WithDataTimestamp(PhemexExchange.ConvertNanosecondsToDateTime(data.TimestampNs), GetTimeOffset())), true);
            return SubscribeAsync(BaseAddress, subscription, ct);
        }

        /// <inheritdoc />
        public Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<PhemexFuturesOrderBook>> onMessage, CancellationToken ct = default)
        {
            var subscription = new PhemexSubscription<PhemexFuturesOrderBook>(_logger, "orderbook_p.subscribe", "orderbook_p.unsubscribe", [symbol, false, 0], "orderbook_p", symbol,
                (received, original, data) => onMessage(new DataEvent<PhemexFuturesOrderBook>(PhemexExchange.Metadata.Id, data, received, original)
                    .WithSymbol(data.Symbol)
                    .WithUpdateType(data.Type == PhemexUpdateType.Snapshot ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                    .WithDataTimestamp(PhemexExchange.ConvertNanosecondsToDateTime(data.TimestampNs), GetTimeOffset())), false, unsubscribeParameters: []);
            // Unsubscribe removes every book on a connection. CEN excludes a connection already
            // carrying this topic, so each book can be released without interrupting another book.
            subscription.Topic = "orderbook_p";
            return SubscribeAsync(BaseAddress, subscription, ct);
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<PhemexFutureTradeUpdate>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, PhemexFutureTradeUpdate>((receiveTime, originalData, data) =>
            {
                if (data.Trades == null || data.Trades.Length == 0)
                    return;

                var timestamp = data.Trades.Max(t => t.Timestamp);
                UpdateTimeOffset(timestamp);

                var updateType = data.Type == PhemexUpdateType.Snapshot
                    ? SocketUpdateType.Snapshot
                    : SocketUpdateType.Update;

                onMessage(
                    new DataEvent<PhemexFutureTradeUpdate>(PhemexExchange.Metadata.Id, data, receiveTime, originalData)
                        .WithUpdateType(updateType)
                        .WithStreamId("trades_p")
                        .WithSymbol(data.Symbol)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var subscription = new PhemexSubscription<PhemexFutureTradeUpdate>(_logger, "trade_p.subscribe", "trade_p.unsubscribe", [symbol], "trades_p", symbol, internalHandler, false);
            return await SubscribeAsync(BaseAddress, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToAllTickerUpdatesAsync(Action<DataEvent<PhemexFutureTickerPackUpdate>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, PhemexFutureTickerPackUpdate>((receiveTime, originalData, data) =>
            {
                var timestamp = data.Timestamp == default ? receiveTime : data.Timestamp;
                UpdateTimeOffset(timestamp);

                onMessage(
                    new DataEvent<PhemexFutureTickerPackUpdate>(PhemexExchange.Metadata.Id, data, receiveTime, originalData)
                        .WithUpdateType(data.Type == PhemexUpdateType.Snapshot ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                        .WithStreamId(data.Method)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var subscription = new PhemexSubscription<PhemexFutureTickerPackUpdate>(
                _logger,
                "perp_market24h_pack_p.subscribe",
                "perp_market24h_pack_p.unsubscribe",
                [],
                "perp_market24h_pack_p.update",
                null,
                internalHandler,
                false);
            return await SubscribeAsync(BaseAddress, subscription, ct).ConfigureAwait(false);
        }
        #endregion
    }
}
