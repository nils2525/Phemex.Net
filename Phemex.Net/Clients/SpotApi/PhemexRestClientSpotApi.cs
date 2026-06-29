using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;
using Phemex.Net.Clients.MessageHandlers;
using Phemex.Net.Interfaces.Clients.SpotApi;
using Phemex.Net.Objects.Internal;
using Phemex.Net.Objects.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Phemex.Net.Clients.SpotApi
{
    /// <inheritdoc cref="IPhemexRestClientSpotApi" />
    internal partial class PhemexRestClientSpotApi : RestApiClient<PhemexEnvironment, PhemexAuthenticationProvider, PhemexCredentials>, IPhemexRestClientSpotApi
    {
        #region Fields
        protected override ErrorMapping ErrorMapping => PhemexErrors.RestErrors;

        /// <inheritdoc />
        public new PhemexRestOptions ClientOptions => (PhemexRestOptions)base.ClientOptions;

        /// <inheritdoc />
        protected override IRestMessageHandler MessageHandler { get; } = new PhemexRestMessageHandler(PhemexErrors.RestErrors);
        #endregion

        #region Api clients
        /// <inheritdoc />
        public IPhemexRestClientSpotApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IPhemexRestClientSpotApiAccount Account { get; }
        /// <inheritdoc />
        public string ExchangeName => "Phemex";
        #endregion

        #region Constructors
        internal PhemexRestClientSpotApi(PhemexRestClient baseClient, ILoggerFactory? loggerFactory, HttpClient? httpClient, PhemexRestOptions options)
            : base(loggerFactory, PhemexExchange.Metadata.Id, httpClient, options.Environment.RestClientSpotAddress, options, options.SpotOptions)
        {
            ExchangeData = new PhemexRestClientSpotApiExchangeData(this);
            Account = new PhemexRestClientSpotApiAccount(this);

            StandardRequestHeaders = new Dictionary<string, string>
            {
                { "User-Agent", "CryptoExchange.Net/" + baseClient.CryptoExchangeLibVersion }
            };
        }
        #endregion

        #region Methods
        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(PhemexExchange._serializerContext);

        /// <inheritdoc />
        protected override PhemexAuthenticationProvider CreateAuthenticationProvider(PhemexCredentials credentials)
            => new PhemexAuthenticationProvider(credentials);

        internal async Task<HttpResult<T>> SendDataAsync<T>(RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
        {
            definition.BaseAddress = BaseAddress;
            var result = await base.SendAsync<PhemexDataResult<T>>(definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            return result.As<T>(result.Data?.Data);
        }

        internal async Task<HttpResult<T[]>> SendRowsDataAsync<T>(RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
        {
            definition.BaseAddress = BaseAddress;
            var result = await base.SendAsync<PhemexDataResult<PhemexRows<T>>>(definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            return result.As<T[]>(result.Data?.Data?.Rows);
        }

        internal async Task<HttpResult<T>> SendMarketAsync<T>(RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
        {
            definition.BaseAddress = BaseAddress;
            var result = await base.SendAsync<PhemexMarketResult<T>>(definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            return result.As<T>(result.Data?.Data);
        }

        /// <inheritdoc />
        protected override Task<HttpResult<DateTime>> GetServerTimestampAsync()
            => Task.FromResult(new HttpResult<DateTime>(PhemexExchange.Metadata.Id, DateTime.UtcNow, null));

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverDate = null)
            => PhemexExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverDate);
        #endregion
    }
}
