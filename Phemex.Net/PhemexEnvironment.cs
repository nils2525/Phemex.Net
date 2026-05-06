using CryptoExchange.Net.Objects;
using Phemex.Net.Objects;

namespace Phemex.Net
{
    /// <summary>
    /// Phemex environments
    /// </summary>
    public class PhemexEnvironment : TradeEnvironment
    {
        /// <summary>
        /// Rest Spot API address
        /// </summary>
        public string RestClientSpotAddress { get; }

        /// <summary>
        /// Socket Spot API address
        /// </summary>
        public string SocketClientSpotAddress { get; }

        internal PhemexEnvironment(
            string name,
            string restSpotAddress,
            string streamSpotAddress) :
            base(name)
        {
            RestClientSpotAddress = restSpotAddress;
            SocketClientSpotAddress = streamSpotAddress;
        }

        /// <summary>
        /// ctor for DI, use <see cref="CreateCustom"/> for creating a custom environment
        /// </summary>
#pragma warning disable CS8618
        public PhemexEnvironment() : base(TradeEnvironmentNames.Live)
#pragma warning restore CS8618
        { }

        /// <summary>
        /// Get the Phemex environment by name
        /// </summary>
        public static PhemexEnvironment? GetEnvironmentByName(string? name)
            => name switch
            {
                TradeEnvironmentNames.Live => Live,
                TradeEnvironmentNames.Testnet => Testnet,
                "" => Live,
                null => Live,
                _ => default
            };

        /// <summary>
        /// Available environment names
        /// </summary>
        public static string[] All => [Live.Name, Testnet.Name];

        /// <summary>
        /// Live environment
        /// </summary>
        public static PhemexEnvironment Live { get; }
            = new PhemexEnvironment(TradeEnvironmentNames.Live,
                                    PhemexApiAddresses.Default.RestClientSpotAddress,
                                    PhemexApiAddresses.Default.SocketClientSpotAddress);

        /// <summary>
        /// Testnet environment
        /// </summary>
        public static PhemexEnvironment Testnet { get; }
            = new PhemexEnvironment(TradeEnvironmentNames.Testnet,
                                    PhemexApiAddresses.TestNet.RestClientSpotAddress,
                                    PhemexApiAddresses.TestNet.SocketClientSpotAddress);

        /// <summary>
        /// Create a custom environment
        /// </summary>
        public static PhemexEnvironment CreateCustom(
            string name,
            string spotRestAddress,
            string spotSocketStreamAddress)
            => new PhemexEnvironment(name, spotRestAddress, spotSocketStreamAddress);
    }
}