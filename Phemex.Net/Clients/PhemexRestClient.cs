using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Phemex.Net.Clients.SpotApi;
using Phemex.Net.Interfaces.Clients;
using Phemex.Net.Interfaces.Clients.SpotApi;
using Phemex.Net.Objects.Options;
using System;
using System.Net.Http;

namespace Phemex.Net.Clients
{
    /// <inheritdoc cref="IPhemexRestClient" />
    public class PhemexRestClient : BaseRestClient<PhemexEnvironment, PhemexCredentials>, IPhemexRestClient
    {
        #region Api clients

        /// <inheritdoc />
        public IPhemexRestClientSpotApi SpotApi { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of the PhemexRestClient using provided options
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public PhemexRestClient(Action<PhemexRestOptions>? optionsDelegate = null)
            : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate)))
        {
        }

        /// <summary>
        /// Create a new instance of the PhemexRestClient using provided options
        /// </summary>
        /// <param name="httpClient">Http client for this client</param>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="options">Option configuration</param>
        public PhemexRestClient(HttpClient? httpClient, ILoggerFactory? loggerFactory, IOptions<PhemexRestOptions> options) : base(loggerFactory, "Phemex")
        {
            Initialize(options.Value);

            SpotApi = AddApiClient(new PhemexRestClientSpotApi(this, _logger, httpClient, options.Value));
        }

        #endregion
        #region Methods

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<PhemexRestOptions> optionsDelegate)
        {
            PhemexRestOptions.Default = ApplyOptionsDelegate(optionsDelegate);
        }

        #endregion
    }
}