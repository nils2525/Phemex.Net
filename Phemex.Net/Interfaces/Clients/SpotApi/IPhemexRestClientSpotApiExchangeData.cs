using CryptoExchange.Net.Objects;
using Phemex.Net.Objects.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Phemex.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Phemex Spot exchange data endpoints. Exchange data includes market data and system status.
    /// </summary>
    public interface IPhemexRestClientSpotApiExchangeData
    {
        /// <summary>
        /// Get product and currency information
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-product-information-3" /><br />
        /// Endpoint:<br />
        /// GET /public/products
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexProductData>> GetProductsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get extended product and currency information
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-product-information-plus-2" /><br />
        /// Endpoint:<br />
        /// GET /public/products-plus
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexProductData>> GetProductsPlusAsync(CancellationToken ct = default);

        /// <summary>
        /// Get server time
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-server-time-2" /><br />
        /// Endpoint:<br />
        /// GET /public/time
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexServerTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get 24-hour spot ticker statistics for all symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-24-hours-ticker-for-all-symbols-2" /><br />
        /// Endpoint:<br />
        /// GET /md/spot/ticker/24hr/all
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexTicker[]>> GetTickersAsync(CancellationToken ct = default);

        /// <summary>
        /// Get 24-hour spot ticker statistics for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-24-hours-ticker-2" /><br />
        /// Endpoint:<br />
        /// GET /md/spot/ticker/24hr
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example <c>sBTCUSDT</c></param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexTicker>> GetTickerAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get order book snapshot
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-order-book-3" /><br />
        /// Endpoint:<br />
        /// GET /md/orderbook
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example <c>sBTCUSDT</c></param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexOrderBook>> GetOrderBookAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get full order book snapshot
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-full-order-book-2" /><br />
        /// Endpoint:<br />
        /// GET /md/fullbook
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example <c>sBTCUSDT</c></param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexOrderBook>> GetFullOrderBookAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get recent trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-recent-trades-2" /><br />
        /// Endpoint:<br />
        /// GET /md/trade
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example <c>sBTCUSDT</c></param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexTradeUpdate>> GetRecentTradesAsync(string symbol, CancellationToken ct = default);
    }
}