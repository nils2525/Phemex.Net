using CryptoExchange.Net.Interfaces.Clients;
using Phemex.Net.Interfaces.Clients.SpotApi;

namespace Phemex.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Phemex websocket API
    /// </summary>
    public interface IPhemexSocketClient : ISocketClient<PhemexCredentials>
    {
        /// <summary>
        /// Spot API endpoints
        /// </summary>
        /// <see cref="IPhemexSocketClientSpotApi"/>
        public IPhemexSocketClientSpotApi SpotApi { get; }
    }
}