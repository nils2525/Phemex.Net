using CryptoExchange.Net.Objects;
using Phemex.Net.Enums;
using Phemex.Net.Objects.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Phemex.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Phemex Spot account and trading endpoints
    /// </summary>
    public interface IPhemexRestClientSpotApiAccount
    {
        /// <summary>
        /// Get spot wallets
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-wallets" /><br />
        /// Endpoint:<br />
        /// GET /spot/wallets
        /// </para>
        /// </summary>
        /// <param name="currency">["<c>currency</c>"] Optional asset filter</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexWallet[]>> GetWalletsAsync(string? currency = null, CancellationToken ct = default);

        /// <summary>
        /// Place a spot order
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#place-order-http-put-prefered-3" /><br />
        /// Endpoint:<br />
        /// PUT /spot/orders/create
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Symbol</param>
        /// <param name="side">["<c>side</c>"] Side</param>
        /// <param name="orderType">["<c>ordType</c>"] Order type</param>
        /// <param name="quantityType">["<c>qtyType</c>"] Quantity type</param>
        /// <param name="baseQuantityEv">["<c>baseQtyEv</c>"] Base quantity, scaled by base currency valueScale</param>
        /// <param name="quoteQuantityEv">["<c>quoteQtyEv</c>"] Quote quantity, scaled by quote currency valueScale</param>
        /// <param name="priceEp">["<c>priceEp</c>"] Price, scaled by priceScale</param>
        /// <param name="clientOrderId">["<c>clOrdID</c>"] Client order id</param>
        /// <param name="timeInForce">["<c>timeInForce</c>"] Time in force</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexOrder>> PlaceOrderAsync(
            string symbol,
            PhemexOrderSide side,
            PhemexOrderType orderType,
            PhemexQuantityType quantityType,
            long? baseQuantityEv = null,
            long? quoteQuantityEv = null,
            long? priceEp = null,
            string? clientOrderId = null,
            PhemexTimeInForce? timeInForce = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel a spot order
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#cancel-order-3" /><br />
        /// Endpoint:<br />
        /// DELETE /spot/orders
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Symbol</param>
        /// <param name="orderId">["<c>orderID</c>"] Order id</param>
        /// <param name="clientOrderId">["<c>clOrdID</c>"] Client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexOrder>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get an open spot order
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-open-order-by-order-id-or-client-order-id" /><br />
        /// Endpoint:<br />
        /// GET /spot/orders/active
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Symbol</param>
        /// <param name="orderId">["<c>orderID</c>"] Order id</param>
        /// <param name="clientOrderId">["<c>clOrdID</c>"] Client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexOrder>> GetOpenOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get open spot orders by symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-all-open-orders-by-symbol" /><br />
        /// Endpoint:<br />
        /// GET /spot/orders
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Symbol</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexOrder[]>> GetOpenOrdersAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get order details by order id or client order id
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-orders-by-order-id-or-client-order-id" /><br />
        /// Endpoint:<br />
        /// GET /api-data/spots/orders/by-order-id
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Symbol</param>
        /// <param name="orderId">["<c>orderID</c>"] Order id</param>
        /// <param name="clientOrderId">["<c>clOrdID</c>"] Client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<PhemexOrder[]>> GetOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get order history
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-order-history" /><br />
        /// Endpoint:<br />
        /// GET /api-data/spots/orders
        /// </para>
        /// </summary>
        Task<WebCallResult<PhemexOrder[]>> GetOrderHistoryAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, int? offset = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get trade history
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-trade-history" /><br />
        /// Endpoint:<br />
        /// GET /api-data/spots/trades
        /// </para>
        /// </summary>
        Task<WebCallResult<PhemexOrderTrade[]>> GetTradeHistoryAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, int? offset = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get recent deposit history
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-recent-deposit-history" /><br />
        /// Endpoint:<br />
        /// GET /exchange/wallets/depositList
        /// </para>
        /// </summary>
        Task<WebCallResult<PhemexDeposit[]>> GetDepositHistoryAsync(string currency, int? offset = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get recent withdrawal history
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-recent-withdraw-history" /><br />
        /// Endpoint:<br />
        /// GET /exchange/wallets/withdrawList
        /// </para>
        /// </summary>
        Task<WebCallResult<PhemexWithdrawal[]>> GetWithdrawalHistoryAsync(string currency, int? offset = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get funds history
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-funds-history" /><br />
        /// Endpoint:<br />
        /// GET /api-data/spots/funds
        /// </para>
        /// </summary>
        Task<WebCallResult<PhemexFundsHistory>> GetFundsHistoryAsync(string currency, DateTime? startTime = null, DateTime? endTime = null, int? offset = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get fee rates by quote currency
        /// <para>
        /// Docs:<br />
        /// <a href="https://phemex-docs.github.io/#query-fee-rate-by-quote-currency" /><br />
        /// Endpoint:<br />
        /// GET /api-data/spots/fee-rate
        /// </para>
        /// </summary>
        Task<WebCallResult<PhemexFeeRates>> GetFeeRatesAsync(string quoteCurrency, CancellationToken ct = default);
    }
}
