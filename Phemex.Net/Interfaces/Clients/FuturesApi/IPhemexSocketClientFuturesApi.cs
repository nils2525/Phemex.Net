using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using Phemex.Net.Objects.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Phemex.Net.Interfaces.Clients.FuturesApi
{
    /// <summary>
    /// Phemex futures streams
    /// </summary>
    public interface IPhemexSocketClientFuturesApi : ISocketApiClient<PhemexCredentials>, IDisposable
    {
        /// <summary>Subscribes to the account-wide USD-margined stream. <see href="https://phemex-docs.github.io/#subscribe-account-order-position-aop-2" />.</summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<PhemexFuturesAccountUpdate>> onMessage, CancellationToken ct = default);

        /// <summary>Subscribes to full-depth USD-margined books. <see href="https://phemex-docs.github.io/#subscribe-orderbook-with-depth-2" />.</summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<PhemexFuturesOrderBook>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to USDT/USDC-margined perpetual trade updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#subscribe-trade-2" /><br />
        /// Endpoint:<br />
        /// wss://ws.phemex.com (method: trade_p.subscribe)
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol to subscribe, for example <c>BTCUSDT</c></param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<PhemexFutureTradeUpdate>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to packed 24-hour ticker updates for all USD-margined perpetual symbols.
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#subscribe-24-hours-ticker-2" /><br />
        /// Endpoint:<br />
        /// wss://ws.phemex.com (method: perp_market24h_pack_p.subscribe)
        /// </para>
        /// </summary>
        /// <param name="onMessage">The event handler for the received data.</param>
        /// <param name="ct">Cancellation token for closing this subscription.</param>
        /// <returns>A stream subscription.</returns>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToAllTickerUpdatesAsync(Action<DataEvent<PhemexFutureTickerPackUpdate>> onMessage, CancellationToken ct = default);
    }
}
