namespace Phemex.Net.Objects
{
    /// <summary>
    /// Api addresses
    /// </summary>
    public class PhemexApiAddresses
    {
        /// <summary>
        /// The address used by the PhemexRestClient for the Spot API
        /// </summary>
        public string RestClientSpotAddress { get; set; } = string.Empty;

        /// <summary>
        /// The address used by the PhemexSocketClient for the websocket Spot API
        /// </summary>
        public string SocketClientSpotAddress { get; set; } = string.Empty;

        /// <summary>
        /// The default addresses to connect to the Phemex API
        /// </summary>
        public static PhemexApiAddresses Default { get; } = new PhemexApiAddresses
        {
            RestClientSpotAddress = "https://api.phemex.com",
            SocketClientSpotAddress = "wss://ws.phemex.com"
        };

        /// <summary>
        /// The testnet addresses to connect to the Phemex API
        /// </summary>
        public static PhemexApiAddresses TestNet { get; } = new PhemexApiAddresses
        {
            RestClientSpotAddress = "https://testnet-api.phemex.com",
            SocketClientSpotAddress = "wss://testnet-api.phemex.com/ws"
        };
    }
}