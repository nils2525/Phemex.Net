using CryptoExchange.Net.Objects.Options;

namespace Phemex.Net.Objects.Options
{
    /// <summary>
    /// Options for the PhemexRestClient
    /// </summary>
    public class PhemexRestOptions : RestExchangeOptions<PhemexEnvironment, PhemexCredentials>
    {
        /// <summary>
        /// Default options for new clients
        /// </summary>
        internal static PhemexRestOptions Default { get; set; } = new PhemexRestOptions()
        {
            Environment = PhemexEnvironment.Live,
            AutoTimestamp = false
        };

        /// <summary>
        /// ctor
        /// </summary>
        public PhemexRestOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// Spot API options
        /// </summary>
        public RestApiOptions SpotOptions { get; private set; } = new RestApiOptions();

        internal PhemexRestOptions Set(PhemexRestOptions targetOptions)
        {
            targetOptions = base.Set<PhemexRestOptions>(targetOptions);
            targetOptions.SpotOptions = SpotOptions.Set(targetOptions.SpotOptions);
            return targetOptions;
        }
    }
}