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
        /// <summary>
        /// Subscribe to USDT/USDC-margined perpetual trade updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#subscribe-trade-4" /><br />
        /// Endpoint:<br />
        /// wss://ws.phemex.com (method: trade_p.subscribe)
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol to subscribe, for example <c>BTCUSDT</c></param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<PhemexFutureTradeUpdate>> onMessage, CancellationToken ct = default);
    }
}
