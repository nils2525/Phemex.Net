using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using Phemex.Net.Objects.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Phemex.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Phemex Spot streams
    /// </summary>
    public interface IPhemexSocketClientSpotApi : ISocketApiClient<PhemexCredentials>, IDisposable
    {
        /// <summary>
        /// Subscribe to trade updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#subscribe-trade-3" /><br />
        /// Endpoint:<br />
        /// wss://ws.phemex.com (method: trade.subscribe)
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol to subscribe, for example <c>sBTCUSDT</c></param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<PhemexTradeUpdate>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to all-symbol spot ticker updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#subscribe-spot-24-hours-ticker" /><br />
        /// Endpoint:<br />
        /// wss://ws.phemex.com (method: spot_market24h.subscribe)
        /// </para>
        /// </summary>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(Action<DataEvent<PhemexSpotTickerUpdate>> onMessage, CancellationToken ct = default);
    }
}