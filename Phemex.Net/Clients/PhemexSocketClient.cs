using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Phemex.Net.Clients.SpotApi;
using Phemex.Net.Interfaces.Clients;
using Phemex.Net.Interfaces.Clients.SpotApi;
using Phemex.Net.Objects.Options;
using System;

namespace Phemex.Net.Clients
{
    /// <inheritdoc cref="IPhemexSocketClient" />
    public class PhemexSocketClient : BaseSocketClient<PhemexEnvironment, PhemexCredentials>, IPhemexSocketClient
    {
        #region Api clients

        /// <inheritdoc />
        public IPhemexSocketClientSpotApi SpotApi { get; }

        #endregion
        #region Constructors

        /// <summary>
        /// Create a new instance of PhemexSocketClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public PhemexSocketClient(Action<PhemexSocketOptions>? optionsDelegate = null)
            : this(Options.Create(ApplyOptionsDelegate(optionsDelegate)), null)
        {
        }

        /// <summary>
        /// Create a new instance of PhemexSocketClient
        /// </summary>
        /// <param name="options">Option configuration</param>
        /// <param name="loggerFactory">The logger factory</param>
        public PhemexSocketClient(IOptions<PhemexSocketOptions> options, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Phemex")
        {
            Initialize(options.Value);

            SpotApi = AddApiClient(new PhemexSocketClientSpotApi(this, _logger, options.Value));
        }

        #endregion
        #region Methods

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<PhemexSocketOptions> optionsDelegate)
        {
            PhemexSocketOptions.Default = ApplyOptionsDelegate(optionsDelegate);
        }

        #endregion
    }
}