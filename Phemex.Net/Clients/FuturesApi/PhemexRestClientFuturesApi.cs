using CryptoExchange.Net.Objects;
using Phemex.Net.Clients.SpotApi;
using Phemex.Net.Enums;
using Phemex.Net.Interfaces.Clients.FuturesApi;
using Phemex.Net.Objects.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Phemex.Net.Clients.FuturesApi;

/// <inheritdoc />
internal sealed class PhemexRestClientFuturesApi : IPhemexRestClientFuturesApi
{
    private static readonly RequestDefinitionCache Definitions = new();
    private readonly PhemexRestClientSpotApi _transport;

    /// <summary>Shares the existing authenticated REST transport and its configured endpoint.</summary>
    internal PhemexRestClientFuturesApi(PhemexRestClientSpotApi transport) => _transport = transport;

    private static RequestDefinition Trading(HttpMethod method, string path)
        => Definitions.GetOrCreate(method, path, PhemexExchange.RateLimiter.PhemexRestContract, 1, true, parameterPosition: HttpMethodParameterPosition.InUri);

    /// <inheritdoc />
    public Task<HttpResult<PhemexFuturesAccountPositions>> GetAccountPositionsAsync(string currency, string? symbol = null, CancellationToken ct = default)
    {
        var parameters = new Parameters(PhemexExchange._parameterSerializationSettings) { { "currency", currency } };
        parameters.AddOptional("symbol", symbol);
        return _transport.SendDataAsync<PhemexFuturesAccountPositions>(Trading(HttpMethod.Get, "/g-accounts/accountPositions"), parameters, ct);
    }

    /// <inheritdoc />
    public Task<HttpResult<PhemexFuturesOrder>> PlaceOrderAsync(string symbol, PhemexOrderSide side, string positionSide, PhemexOrderType orderType, decimal quantity, decimal? price = null, string? clientOrderId = null, PhemexTimeInForce? timeInForce = null, bool reduceOnly = false, CancellationToken ct = default)
    {
        var parameters = new Parameters(PhemexExchange._parameterSerializationSettings) { { "symbol", symbol }, { "posSide", positionSide }, { "orderQtyRq", quantity }, { "reduceOnly", reduceOnly } };
        parameters.AddEnum("side", side);
        parameters.AddEnum("ordType", orderType);
        parameters.AddOptional("priceRp", price);
        parameters.AddOptional("clOrdID", clientOrderId);
        parameters.AddOptionalEnum("timeInForce", timeInForce);
        return _transport.SendDataAsync<PhemexFuturesOrder>(Trading(HttpMethod.Put, "/g-orders/create"), parameters, ct);
    }

    /// <inheritdoc />
    public Task<HttpResult<PhemexFuturesOrder>> CancelOrderAsync(string symbol, string positionSide, string orderId, CancellationToken ct = default)
    {
        var parameters = new Parameters(PhemexExchange._parameterSerializationSettings) { { "symbol", symbol }, { "posSide", positionSide }, { "orderID", orderId } };
        return _transport.SendDataAsync<PhemexFuturesOrder>(Trading(HttpMethod.Delete, "/g-orders/cancel"), parameters, ct);
    }

    /// <inheritdoc />
    public Task<HttpResult<PhemexFuturesOrder[]>> GetOpenOrdersAsync(string symbol, CancellationToken ct = default)
        => _transport.SendRowsDataAsync<PhemexFuturesOrder>(Trading(HttpMethod.Get, "/g-orders/activeList"), new Parameters(PhemexExchange._parameterSerializationSettings) { { "symbol", symbol } }, ct);

    /// <inheritdoc />
    public Task<HttpResult<PhemexFuturesHistoryOrder[]>> GetOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(orderId) && string.IsNullOrWhiteSpace(clientOrderId))
            throw new ArgumentException("An order ID or client order ID is required.");
        var parameters = new Parameters(PhemexExchange._parameterSerializationSettings) { { "symbol", symbol } };
        parameters.AddOptional("orderID", orderId);
        parameters.AddOptional("clOrdID", clientOrderId);
        return _transport.SendRowsDataAsync<PhemexFuturesHistoryOrder>(Definitions.GetOrCreate(HttpMethod.Get, "/api-data/g-futures/orders/by-order-id", PhemexExchange.RateLimiter.PhemexRestOther, 1, true), parameters, ct);
    }

    /// <inheritdoc />
    public Task<HttpResult<PhemexFuturesTrade[]>> GetTradesAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, int? offset = null, int? limit = null, CancellationToken ct = default)
    {
        var parameters = new Parameters(PhemexExchange._parameterSerializationSettings) { { "symbol", symbol } };
        parameters.AddOptional("start", startTime.HasValue ? new DateTimeOffset(startTime.Value).ToUnixTimeMilliseconds() : null);
        parameters.AddOptional("end", endTime.HasValue ? new DateTimeOffset(endTime.Value).ToUnixTimeMilliseconds() : null);
        parameters.AddOptional("offset", offset);
        parameters.AddOptional("limit", limit);
        return _transport.SendRowsDataAsync<PhemexFuturesTrade>(Definitions.GetOrCreate(HttpMethod.Get, "/api-data/g-futures/trades", PhemexExchange.RateLimiter.PhemexRestOther, 1, true), parameters, ct);
    }

    /// <inheritdoc />
    public Task<HttpResult<string>> SetPositionModeAsync(string symbol, string positionMode, CancellationToken ct = default)
        => _transport.SendDataAsync<string>(Trading(HttpMethod.Put, "/g-positions/switch-pos-mode-sync"), new Parameters(PhemexExchange._parameterSerializationSettings) { { "symbol", symbol }, { "targetPosMode", positionMode } }, ct);

    /// <inheritdoc />
    public Task<HttpResult<string>> SetLeverageAsync(string symbol, decimal leverage, bool hedged, CancellationToken ct = default)
    {
        var parameters = new Parameters(PhemexExchange._parameterSerializationSettings) { { "symbol", symbol } };
        if (hedged)
        {
            parameters.Add("longLeverageRr", leverage);
            parameters.Add("shortLeverageRr", leverage);
        }
        else
            parameters.Add("leverageRr", leverage);
        return _transport.SendDataAsync<string>(Trading(HttpMethod.Put, "/g-positions/leverage"), parameters, ct);
    }

    /// <inheritdoc />
    public Task<HttpResult<PhemexFuturesTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
        => _transport.SendMarketAsync<PhemexFuturesTicker>(Definitions.GetOrCreate(HttpMethod.Get, "/md/v3/ticker/24hr", PhemexExchange.RateLimiter.PhemexRestOther, 1, false), new Parameters(PhemexExchange._parameterSerializationSettings) { { "symbol", symbol } }, ct);

    /// <inheritdoc />
    public Task<HttpResult<PhemexFundingRate[]>> GetFundingRatesAsync(string? symbol = null, int? page = null, int? pageSize = null, CancellationToken ct = default)
    {
        var parameters = new Parameters(PhemexExchange._parameterSerializationSettings);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("pageNum", page);
        parameters.AddOptional("pageSize", pageSize);
        return _transport.SendRowsDataAsync<PhemexFundingRate>(Definitions.GetOrCreate(HttpMethod.Get, "/contract-biz/public/real-funding-rates", PhemexExchange.RateLimiter.PhemexRestOther, 1, false), parameters, ct);
    }

    /// <inheritdoc />
    public Task<HttpResult<PhemexFundingFee[]>> GetFundingFeesAsync(string symbol, int? offset = null, int? limit = null, CancellationToken ct = default)
    {
        var parameters = new Parameters(PhemexExchange._parameterSerializationSettings) { { "symbol", symbol } };
        parameters.AddOptional("offset", offset);
        parameters.AddOptional("limit", limit);
        return _transport.SendRowsDataAsync<PhemexFundingFee>(Definitions.GetOrCreate(HttpMethod.Get, "/api-data/g-futures/funding-fees", PhemexExchange.RateLimiter.PhemexRestOther, 1, true), parameters, ct);
    }

    /// <inheritdoc />
    public Task<HttpResult<PhemexWalletTransfer>> TransferAsync(string currency, decimal amount, long amountEv, string fromAccount, string toAccount, CancellationToken ct = default)
    {
        var parameters = new Parameters(PhemexExchange._parameterSerializationSettings) { { "currency", currency }, { "amount", amount }, { "amountEv", amountEv }, { "fromAccType", fromAccount }, { "toAccType", toAccount } };
        return _transport.SendDataAsync<PhemexWalletTransfer>(Definitions.GetOrCreate(HttpMethod.Post, "/wallets/account/transfer", PhemexExchange.RateLimiter.PhemexRestOther, 1, true), parameters, ct);
    }
}
