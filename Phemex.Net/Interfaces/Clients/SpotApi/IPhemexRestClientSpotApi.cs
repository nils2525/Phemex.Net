using CryptoExchange.Net.Interfaces.Clients;
using System;

namespace Phemex.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Phemex Spot API endpoints
    /// </summary>
    public interface IPhemexRestClientSpotApi : IRestApiClient<PhemexCredentials>, IDisposable
    {
        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        /// <see cref="IPhemexRestClientSpotApiExchangeData" />
        public IPhemexRestClientSpotApiExchangeData ExchangeData { get; }
    }
}