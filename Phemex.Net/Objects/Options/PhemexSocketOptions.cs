using CryptoExchange.Net.Objects.Options;

namespace Phemex.Net.Objects.Options
{
    /// <summary>
    /// Options for the PhemexSocketClient
    /// </summary>
    public class PhemexSocketOptions : SocketExchangeOptions<PhemexEnvironment, PhemexCredentials>
    {
        /// <summary>
        /// Default options for new clients
        /// </summary>
        internal static PhemexSocketOptions Default { get; set; } = new PhemexSocketOptions()
        {
            Environment = PhemexEnvironment.Live,
            SocketSubscriptionsCombineTarget = 10,
        };

        /// <summary>
        /// ctor
        /// </summary>
        public PhemexSocketOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// Spot API options
        /// </summary>
        public SocketApiOptions SpotOptions { get; private set; } = new SocketApiOptions();
        /// <summary>
        /// Futures API options
        /// </summary>
        public SocketApiOptions FuturesOptions { get; private set; } = new SocketApiOptions();

        internal PhemexSocketOptions Set(PhemexSocketOptions targetOptions)
        {
            targetOptions = base.Set<PhemexSocketOptions>(targetOptions);
            targetOptions.SpotOptions = SpotOptions.Set(targetOptions.SpotOptions);
            targetOptions.FuturesOptions = FuturesOptions.Set(targetOptions.FuturesOptions);
            return targetOptions;
        }
    }
}
