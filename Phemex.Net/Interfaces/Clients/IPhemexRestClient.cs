using CryptoExchange.Net.Interfaces.Clients;
using Phemex.Net.Interfaces.Clients.SpotApi;

namespace Phemex.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Phemex Rest API.
    /// </summary>
    public interface IPhemexRestClient : IRestClient<PhemexCredentials>
    {
        /// <summary>
        /// Spot API endpoints
        /// </summary>
        /// <see cref="IPhemexRestClientSpotApi"/>
        public IPhemexRestClientSpotApi SpotApi { get; }
    }
}