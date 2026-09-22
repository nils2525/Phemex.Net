using CryptoExchange.Net.Objects;
using Phemex.Net.Enums;
using Phemex.Net.Objects.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Phemex.Net.Interfaces.Clients.FuturesApi;

/// <summary>USD-margined perpetual trading and market data endpoints.</summary>
public interface IPhemexRestClientFuturesApi
{
    /// <summary>Gets account balances and position configuration. <see href="https://phemex-docs.github.io/#query-account-positions" />.</summary>
    Task<HttpResult<PhemexFuturesAccountPositions>> GetAccountPositionsAsync(string currency, string? symbol = null, CancellationToken ct = default);
    /// <summary>Places an order using unscaled price and base quantity. <see href="https://phemex-docs.github.io/#place-order-http-put-prefered-2" />.</summary>
    Task<HttpResult<PhemexFuturesOrder>> PlaceOrderAsync(string symbol, PhemexOrderSide side, string positionSide, PhemexOrderType orderType, decimal quantity, decimal? price = null, string? clientOrderId = null, PhemexTimeInForce? timeInForce = null, bool reduceOnly = false, CancellationToken ct = default);
    /// <summary>Cancels an order on its native position side. <see href="https://phemex-docs.github.io/#cancel-single-order-by-orderid" />.</summary>
    Task<HttpResult<PhemexFuturesOrder>> CancelOrderAsync(string symbol, string positionSide, string orderId, CancellationToken ct = default);
    /// <summary>Gets open orders for a symbol. <see href="https://phemex-docs.github.io/#query-open-orders-by-symbol-2" />.</summary>
    Task<HttpResult<PhemexFuturesOrder[]>> GetOpenOrdersAsync(string symbol, CancellationToken ct = default);
    /// <summary>Gets historical orders by exchange or client identifier. <see href="https://phemex-docs.github.io/#query-orders-by-ids" />.</summary>
    Task<HttpResult<PhemexFuturesHistoryOrder[]>> GetOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);
    /// <summary>Gets execution history with offset pagination. <see href="https://phemex-docs.github.io/#query-trades-history" />.</summary>
    Task<HttpResult<PhemexFuturesTrade[]>> GetTradesAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, int? offset = null, int? limit = null, CancellationToken ct = default);
    /// <summary>Switches OneWay or Hedged position mode. <see href="https://phemex-docs.github.io/#switch-position-mode-synchronously" />.</summary>
    Task<HttpResult<string>> SetPositionModeAsync(string symbol, string positionMode, CancellationToken ct = default);
    /// <summary>Sets signed leverage: negative for cross and positive for isolated. <see href="https://phemex-docs.github.io/#set-leverage-2" />.</summary>
    Task<HttpResult<string>> SetLeverageAsync(string symbol, decimal leverage, bool hedged, CancellationToken ct = default);
    /// <summary>Gets a current unscaled ticker. <see href="https://phemex-docs.github.io/#query-24-ticker" />.</summary>
    Task<HttpResult<PhemexFuturesTicker>> GetTickerAsync(string symbol, CancellationToken ct = default);
    /// <summary>Gets current funding rates and their actual next settlement time. <see href="https://phemex-docs.github.io/#query-real-funding-rates" />.</summary>
    Task<HttpResult<PhemexFundingRate[]>> GetFundingRatesAsync(string? symbol = null, int? page = null, int? pageSize = null, CancellationToken ct = default);
    /// <summary>Gets posted funding fees with offset pagination. <see href="https://phemex-docs.github.io/#query-funding-fee-history-2" />.</summary>
    Task<HttpResult<PhemexFundingFee[]>> GetFundingFeesAsync(string symbol, int? offset = null, int? limit = null, CancellationToken ct = default);
    /// <summary>Transfers between wallets with both unscaled and scaled amounts. <see href="https://phemex-docs.github.io/#transfer-between-wallets-within-an-account" />.</summary>
    Task<HttpResult<PhemexWalletTransfer>> TransferAsync(string currency, decimal amount, long amountEv, string fromAccount, string toAccount, CancellationToken ct = default);
}
