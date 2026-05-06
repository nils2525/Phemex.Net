using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Phemex.Net.Interfaces.Clients;
using Phemex.Net.Objects.Options;
using System;
using System.Collections.Concurrent;
using System.Net.Http;

namespace Phemex.Net.Clients
{
    /// <inheritdoc />
    public class PhemexUserClientProvider : IPhemexUserClientProvider
    {
        private readonly ConcurrentDictionary<string, IPhemexRestClient> _restClients = new ConcurrentDictionary<string, IPhemexRestClient>();
        private readonly ConcurrentDictionary<string, IPhemexSocketClient> _socketClients = new ConcurrentDictionary<string, IPhemexSocketClient>();

        private readonly IOptions<PhemexRestOptions> _restOptions;
        private readonly IOptions<PhemexSocketOptions> _socketOptions;
        private readonly HttpClient _httpClient;
        private readonly ILoggerFactory? _loggerFactory;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="optionsDelegate">Options to use for created clients</param>
        public PhemexUserClientProvider(Action<PhemexOptions>? optionsDelegate = null)
            : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate).Rest), Options.Create(ApplyOptionsDelegate(optionsDelegate).Socket))
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public PhemexUserClientProvider(
            HttpClient? httpClient,
            ILoggerFactory? loggerFactory,
            IOptions<PhemexRestOptions> restOptions,
            IOptions<PhemexSocketOptions> socketOptions)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.Timeout = restOptions.Value.RequestTimeout;
            _loggerFactory = loggerFactory;
            _restOptions = restOptions;
            _socketOptions = socketOptions;
        }

        /// <inheritdoc />
        public void InitializeUserClient(string userIdentifier, PhemexCredentials credentials, PhemexEnvironment? environment = null)
        {
            CreateRestClient(userIdentifier, credentials, environment);
            CreateSocketClient(userIdentifier, credentials, environment);
        }

        /// <inheritdoc />
        public void ClearUserClients(string userIdentifier)
        {
            _restClients.TryRemove(userIdentifier, out _);
            _socketClients.TryRemove(userIdentifier, out _);
        }

        /// <inheritdoc />
        public IPhemexRestClient GetRestClient(string userIdentifier, PhemexCredentials? credentials = null, PhemexEnvironment? environment = null)
        {
            if (!_restClients.TryGetValue(userIdentifier, out var client) || client.Disposed)
                client = CreateRestClient(userIdentifier, credentials, environment);

            return client;
        }

        /// <inheritdoc />
        public IPhemexSocketClient GetSocketClient(string userIdentifier, PhemexCredentials? credentials = null, PhemexEnvironment? environment = null)
        {
            if (!_socketClients.TryGetValue(userIdentifier, out var client) || client.Disposed)
                client = CreateSocketClient(userIdentifier, credentials, environment);

            return client;
        }

        private IPhemexRestClient CreateRestClient(string userIdentifier, PhemexCredentials? credentials, PhemexEnvironment? environment)
        {
            var clientRestOptions = SetRestEnvironment(environment);
            var client = new PhemexRestClient(_httpClient, _loggerFactory, clientRestOptions);
            if (credentials != null)
            {
                client.SetApiCredentials(credentials);
                _restClients[userIdentifier] = client;
            }
            return client;
        }

        private IPhemexSocketClient CreateSocketClient(string userIdentifier, PhemexCredentials? credentials, PhemexEnvironment? environment)
        {
            var clientSocketOptions = SetSocketEnvironment(environment);
            var client = new PhemexSocketClient(clientSocketOptions, _loggerFactory);
            if (credentials != null)
            {
                client.SetApiCredentials(credentials);
                _socketClients[userIdentifier] = client;
            }
            return client;
        }

        private IOptions<PhemexRestOptions> SetRestEnvironment(PhemexEnvironment? environment)
        {
            if (environment == null)
                return _restOptions;

            var newRestClientOptions = new PhemexRestOptions();
            _restOptions.Value.Set(newRestClientOptions);
            newRestClientOptions.Environment = environment;
            return Options.Create(newRestClientOptions);
        }

        private IOptions<PhemexSocketOptions> SetSocketEnvironment(PhemexEnvironment? environment)
        {
            if (environment == null)
                return _socketOptions;

            var newSocketClientOptions = new PhemexSocketOptions();
            _socketOptions.Value.Set(newSocketClientOptions);
            newSocketClientOptions.Environment = environment;
            return Options.Create(newSocketClientOptions);
        }

        private static T ApplyOptionsDelegate<T>(Action<T>? del) where T : new()
        {
            var opts = new T();
            del?.Invoke(opts);
            return opts;
        }
    }
}