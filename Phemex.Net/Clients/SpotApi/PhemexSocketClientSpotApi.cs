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
using Phemex.Net.Interfaces.Clients.SpotApi;
using Phemex.Net.Objects.Models;
using Phemex.Net.Objects.Options;
using Phemex.Net.Objects.Sockets;
using Phemex.Net.Objects.Sockets.Subscriptions;
using System;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Phemex.Net.Clients.SpotApi
{
    /// <summary>
    /// Client providing access to the Phemex Spot websocket Api
    /// </summary>
    internal partial class PhemexSocketClientSpotApi : SocketApiClient<PhemexEnvironment, PhemexAuthenticationProvider, PhemexCredentials>, IPhemexSocketClientSpotApi
    {
        #region Constructors
        internal PhemexSocketClientSpotApi(PhemexSocketClient baseClient, ILogger logger, PhemexSocketOptions options) :
            base(logger, options.Environment.SocketClientSpotAddress, options, options.SpotOptions)
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
            // Phemex can emit index tick frames on authenticated wallet/order streams.
            // They are unrelated to the active subscription and should not be treated as malformed messages.
            if (typeIdentifier == "tick")
                return true;

            return base.HandleUnhandledMessage(connection, typeIdentifier, data);
        }

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverDate = null)
            => PhemexExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverDate);

        /// <inheritdoc />
        protected override PhemexAuthenticationProvider CreateAuthenticationProvider(PhemexCredentials credentials)
            => new PhemexAuthenticationProvider(credentials);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<PhemexTradeUpdate>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, PhemexTradeUpdate>((receiveTime, originalData, data) =>
            {
                if (data.Trades == null || data.Trades.Length == 0)
                    return;

                var timestamp = data.Trades.Max(t => t.Timestamp);
                UpdateTimeOffset(timestamp);

                var updateType = data.Type == PhemexUpdateType.Snapshot
                    ? SocketUpdateType.Snapshot
                    : SocketUpdateType.Update;

                onMessage(
                    new DataEvent<PhemexTradeUpdate>(PhemexExchange.Metadata.Id, data, receiveTime, originalData)
                        .WithUpdateType(updateType)
                        .WithStreamId("trades")
                        .WithSymbol(data.Symbol)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var subscription = new PhemexSubscription<PhemexTradeUpdate>(_logger, "trade.subscribe", "trade.unsubscribe", [symbol], "trades", symbol, internalHandler, false);
            return await SubscribeAsync(BaseAddress, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(Action<DataEvent<PhemexSpotTickerUpdate>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, PhemexSpotTickerUpdate>((receiveTime, originalData, data) =>
            {
                if (data.Ticker == null)
                    return;

                var timestamp = data.Ticker.Timestamp == default ? data.Timestamp : data.Ticker.Timestamp;
                UpdateTimeOffset(timestamp);

                onMessage(
                    new DataEvent<PhemexSpotTickerUpdate>(PhemexExchange.Metadata.Id, data, receiveTime, originalData)
                        .WithUpdateType(SocketUpdateType.Update)
                        .WithStreamId("spot_market24h")
                        .WithSymbol(data.Ticker.Symbol)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var subscription = new PhemexSubscription<PhemexSpotTickerUpdate>(_logger, "spot_market24h.subscribe", "spot_market24h.unsubscribe", [], "spot_market24h", null, internalHandler, false);
            return await SubscribeAsync(BaseAddress, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, bool fullBook, Action<DataEvent<PhemexOrderBook>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, PhemexOrderBook>((receiveTime, originalData, data) =>
            {
                var timestamp = data.Timestamp == default ? receiveTime : data.Timestamp;
                UpdateTimeOffset(timestamp);

                var updateType = data.Type == PhemexUpdateType.Snapshot
                    ? SocketUpdateType.Snapshot
                    : SocketUpdateType.Update;

                onMessage(
                    new DataEvent<PhemexOrderBook>(PhemexExchange.Metadata.Id, data, receiveTime, originalData)
                        .WithUpdateType(updateType)
                        .WithStreamId("book")
                        .WithSymbol(data.Symbol)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var parameters = fullBook ? new object[] { symbol, true } : new object[] { symbol };
            var subscription = new PhemexOrderBookSubscription(_logger, parameters, symbol, internalHandler);
            return await SubscribeAsync(BaseAddress, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToWalletOrderUpdatesAsync(Action<DataEvent<PhemexWalletOrderUpdate>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, PhemexWalletOrderUpdate>((receiveTime, originalData, data) =>
            {
                var timestamp = data.Timestamp == default ? receiveTime : data.Timestamp;
                UpdateTimeOffset(timestamp);

                var updateType = data.Type == PhemexUpdateType.Snapshot
                    ? SocketUpdateType.Snapshot
                    : SocketUpdateType.Update;

                onMessage(
                    new DataEvent<PhemexWalletOrderUpdate>(PhemexExchange.Metadata.Id, data, receiveTime, originalData)
                        .WithUpdateType(updateType)
                        .WithStreamId("wallet-order")
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var subscription = new PhemexSubscription<PhemexWalletOrderUpdate>(_logger, "wo.subscribe", "wo.unsubscribe", [], "wallets", null, internalHandler, true);
            return await SubscribeAsync(BaseAddress, subscription, ct).ConfigureAwait(false);
        }
        #endregion
    }
}
