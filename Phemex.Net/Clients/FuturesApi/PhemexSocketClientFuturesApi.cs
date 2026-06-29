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
        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(PhemexExchange._serializerContext);
        /// <inheritdoc />
        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType) => new PhemexSocketMessageHandler();

        /// <inheritdoc />
        protected override bool HandleUnhandledMessage(SocketConnection connection, string typeIdentifier, ReadOnlySpan<byte> data)
        {
            if (IsSuccessAcknowledgement(data))
                return true;

            return base.HandleUnhandledMessage(connection, typeIdentifier, data);
        }

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
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverDate = null)
            => PhemexExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverDate);

        /// <inheritdoc />
        protected override PhemexAuthenticationProvider CreateAuthenticationProvider(PhemexCredentials credentials)
            => new PhemexAuthenticationProvider(credentials);

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
        #endregion
    }
}
