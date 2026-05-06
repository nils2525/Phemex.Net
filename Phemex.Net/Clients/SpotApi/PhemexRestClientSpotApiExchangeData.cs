using CryptoExchange.Net.Objects;
using Phemex.Net.Interfaces.Clients.SpotApi;
using Phemex.Net.Objects.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Phemex.Net.Clients.SpotApi
{
    /// <inheritdoc />
    internal class PhemexRestClientSpotApiExchangeData : IPhemexRestClientSpotApiExchangeData
    {
        private readonly PhemexRestClientSpotApi _baseClient;
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        internal PhemexRestClientSpotApiExchangeData(PhemexRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Methods
        /// <inheritdoc />
        public async Task<WebCallResult<PhemexProductData>> GetProductsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/public/products", PhemexExchange.RateLimiter.PhemexRestIp, 1, false);
            return await _baseClient.SendDataAsync<PhemexProductData>(request, null, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<PhemexProductData>> GetProductsPlusAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/public/products-plus", PhemexExchange.RateLimiter.PhemexRestIp, 1, false);
            return await _baseClient.SendDataAsync<PhemexProductData>(request, null, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<PhemexServerTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/public/time", PhemexExchange.RateLimiter.PhemexRestIp, 1, false);
            return await _baseClient.SendDataAsync<PhemexServerTime>(request, null, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<PhemexTicker[]>> GetTickersAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/md/spot/ticker/24hr/all", PhemexExchange.RateLimiter.PhemexRestIp, 1, false);
            return await _baseClient.SendMarketAsync<PhemexTicker[]>(request, null, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<PhemexTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "symbol", symbol }
            };
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/md/spot/ticker/24hr", PhemexExchange.RateLimiter.PhemexRestIp, 1, false);
            return await _baseClient.SendMarketAsync<PhemexTicker>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<PhemexOrderBook>> GetOrderBookAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "symbol", symbol }
            };
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/md/orderbook", PhemexExchange.RateLimiter.PhemexRestIp, 1, false);
            return await _baseClient.SendMarketAsync<PhemexOrderBook>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<PhemexOrderBook>> GetFullOrderBookAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "symbol", symbol }
            };
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/md/fullbook", PhemexExchange.RateLimiter.PhemexRestIp, 1, false);
            return await _baseClient.SendMarketAsync<PhemexOrderBook>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<PhemexTradeUpdate>> GetRecentTradesAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "symbol", symbol }
            };
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/md/trade", PhemexExchange.RateLimiter.PhemexRestIp, 1, false);
            return await _baseClient.SendMarketAsync<PhemexTradeUpdate>(request, parameters, ct).ConfigureAwait(false);
        }
        #endregion
    }
}