using CryptoExchange.Net.Objects;
using Phemex.Net.Enums;
using Phemex.Net.Interfaces.Clients.SpotApi;
using Phemex.Net.Objects.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Phemex.Net.Clients.SpotApi
{
    /// <inheritdoc />
    internal class PhemexRestClientSpotApiAccount : IPhemexRestClientSpotApiAccount
    {
        private readonly PhemexRestClientSpotApi _baseClient;
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        internal PhemexRestClientSpotApiAccount(PhemexRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Methods
        /// <inheritdoc />
        public async Task<HttpResult<PhemexWallet[]>> GetWalletsAsync(string? currency = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PhemexExchange._parameterSerializationSettings);
            parameters.AddOptional("currency", currency);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/spot/wallets", PhemexExchange.RateLimiter.PhemexRestIp, 1, true);
            return await _baseClient.SendDataAsync<PhemexWallet[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<PhemexOrder>> PlaceOrderAsync(
            string symbol,
            PhemexOrderSide side,
            PhemexOrderType orderType,
            PhemexQuantityType quantityType,
            long? baseQuantityEv = null,
            long? quoteQuantityEv = null,
            long? priceEp = null,
            string? clientOrderId = null,
            PhemexTimeInForce? timeInForce = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(PhemexExchange._parameterSerializationSettings){
                { "symbol", symbol }
            };
            parameters.AddEnum("side", side);
            parameters.AddEnum("ordType", orderType);
            parameters.AddEnum("qtyType", quantityType);
            parameters.AddOptional("baseQtyEv", baseQuantityEv);
            parameters.AddOptional("quoteQtyEv", quoteQuantityEv);
            parameters.AddOptional("priceEp", priceEp);
            parameters.AddOptional("clOrdID", clientOrderId);
            parameters.AddOptionalEnum("timeInForce", timeInForce);

            var request = _definitions.GetOrCreate(HttpMethod.Put, "/spot/orders/create", PhemexExchange.RateLimiter.PhemexRestIp, 1, true, parameterPosition: HttpMethodParameterPosition.InUri);
            return await _baseClient.SendDataAsync<PhemexOrder>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<PhemexOrder>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(orderId) && string.IsNullOrWhiteSpace(clientOrderId))
                throw new ArgumentException("Either orderId or clientOrderId must be supplied.");

            var parameters = new Parameters(PhemexExchange._parameterSerializationSettings){
                { "symbol", symbol }
            };
            parameters.AddOptional("orderID", orderId);
            parameters.AddOptional("clOrdID", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Delete, "/spot/orders", PhemexExchange.RateLimiter.PhemexRestIp, 2, true, parameterPosition: HttpMethodParameterPosition.InUri);
            return await _baseClient.SendDataAsync<PhemexOrder>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<PhemexOrder>> GetOpenOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(orderId) && string.IsNullOrWhiteSpace(clientOrderId))
                throw new ArgumentException("Either orderId or clientOrderId must be supplied.");

            var parameters = new Parameters(PhemexExchange._parameterSerializationSettings){
                { "symbol", symbol }
            };
            parameters.AddOptional("orderID", orderId);
            parameters.AddOptional("clOrdID", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/spot/orders/active", PhemexExchange.RateLimiter.PhemexRestIp, 1, true);
            return await _baseClient.SendDataAsync<PhemexOrder>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<PhemexOrder[]>> GetOpenOrdersAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(PhemexExchange._parameterSerializationSettings){
                { "symbol", symbol }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/spot/orders", PhemexExchange.RateLimiter.PhemexRestIp, 1, true);
            return await _baseClient.SendDataAsync<PhemexOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<PhemexOrder[]>> GetOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(orderId) && string.IsNullOrWhiteSpace(clientOrderId))
                throw new ArgumentException("Either orderId or clientOrderId must be supplied.");

            var parameters = new Parameters(PhemexExchange._parameterSerializationSettings){
                { "symbol", symbol }
            };
            parameters.AddOptional("orderID", orderId);
            parameters.AddOptional("clOrdID", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api-data/spots/orders/by-order-id", PhemexExchange.RateLimiter.PhemexRestIp, 1, true);
            return await _baseClient.SendRowsDataAsync<PhemexOrder>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<PhemexOrder[]>> GetOrderHistoryAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, int? offset = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = CreateHistoryParameters(symbol, startTime, endTime, offset, limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api-data/spots/orders", PhemexExchange.RateLimiter.PhemexRestIp, 1, true);
            return await _baseClient.SendDataAsync<PhemexOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<PhemexOrderTrade[]>> GetTradeHistoryAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, int? offset = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = CreateHistoryParameters(symbol, startTime, endTime, offset, limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api-data/spots/trades", PhemexExchange.RateLimiter.PhemexRestIp, 1, true);
            return await _baseClient.SendRowsDataAsync<PhemexOrderTrade>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<PhemexDeposit[]>> GetDepositHistoryAsync(string currency, int? offset = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PhemexExchange._parameterSerializationSettings){
                { "currency", currency }
            };
            parameters.AddOptional("offset", offset);
            parameters.AddOptional("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/exchange/wallets/depositList", PhemexExchange.RateLimiter.PhemexRestIp, 1, true);
            return await _baseClient.SendDataAsync<PhemexDeposit[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<PhemexWithdrawal[]>> GetWithdrawalHistoryAsync(string currency, int? offset = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PhemexExchange._parameterSerializationSettings){
                { "currency", currency }
            };
            parameters.AddOptional("offset", offset);
            parameters.AddOptional("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/exchange/wallets/withdrawList", PhemexExchange.RateLimiter.PhemexRestIp, 1, true);
            return await _baseClient.SendDataAsync<PhemexWithdrawal[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<PhemexFundsHistory>> GetFundsHistoryAsync(string currency, DateTime? startTime = null, DateTime? endTime = null, int? offset = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PhemexExchange._parameterSerializationSettings){
                { "currency", currency }
            };
            parameters.AddOptionalMilliseconds("start", startTime);
            parameters.AddOptionalMilliseconds("end", endTime);
            parameters.AddOptional("offset", offset);
            parameters.AddOptional("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api-data/spots/funds", PhemexExchange.RateLimiter.PhemexRestIp, 1, true);
            return await _baseClient.SendDataAsync<PhemexFundsHistory>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<PhemexFeeRates>> GetFeeRatesAsync(string quoteCurrency, CancellationToken ct = default)
        {
            var parameters = new Parameters(PhemexExchange._parameterSerializationSettings){
                { "quoteCurrency", quoteCurrency }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api-data/spots/fee-rate", PhemexExchange.RateLimiter.PhemexRestIp, 1, true);
            return await _baseClient.SendDataAsync<PhemexFeeRates>(request, parameters, ct).ConfigureAwait(false);
        }

        private static Parameters CreateHistoryParameters(string symbol, DateTime? startTime, DateTime? endTime, int? offset, int? limit)
        {
            var parameters = new Parameters(PhemexExchange._parameterSerializationSettings){
                { "symbol", symbol }
            };
            parameters.AddOptionalMilliseconds("start", startTime);
            parameters.AddOptionalMilliseconds("end", endTime);
            parameters.AddOptional("offset", offset);
            parameters.AddOptional("limit", limit);
            return parameters;
        }
        #endregion
    }
}
