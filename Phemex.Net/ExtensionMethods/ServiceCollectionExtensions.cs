using CryptoExchange.Net;
using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Phemex.Net;
using Phemex.Net.Clients;
using Phemex.Net.Interfaces.Clients;
using Phemex.Net.Objects.Options;
using System;
using System.Net.Http;
using System.Threading;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions for DI
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services such as the IPhemexRestClient and IPhemexSocketClient. Configures the services based on the provided configuration.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="configuration">The configuration(section) containing the options</param>
        public static IServiceCollection AddPhemex(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var options = new PhemexOptions();
            options.Rest.Environment = null!;
            options.Socket.Environment = null!;
            try
            {
                configuration.Bind(options);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Invalid configuration provided", ex);
            }

            if (options.Rest == null || options.Socket == null)
                throw new ArgumentException("Options null");

            var restEnvName = options.Rest.Environment?.Name ?? options.Environment?.Name ?? PhemexEnvironment.Live.Name;
            var socketEnvName = options.Socket.Environment?.Name ?? options.Environment?.Name ?? PhemexEnvironment.Live.Name;
            options.Rest.Environment = PhemexEnvironment.GetEnvironmentByName(restEnvName) ?? options.Rest.Environment!;
            options.Rest.ApiCredentials = options.Rest.ApiCredentials ?? options.ApiCredentials;
            options.Socket.Environment = PhemexEnvironment.GetEnvironmentByName(socketEnvName) ?? options.Socket.Environment!;
            options.Socket.ApiCredentials = options.Socket.ApiCredentials ?? options.ApiCredentials;

            services.AddSingleton(x => Options.Options.Create(options.Rest));
            services.AddSingleton(x => Options.Options.Create(options.Socket));

            return AddPhemexCore(services, options.SocketClientLifeTime);
        }

        /// <summary>
        /// Add services such as the IPhemexRestClient and IPhemexSocketClient. Services will be configured based on the provided options.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="optionsDelegate">Set options for the Phemex services</param>
        public static IServiceCollection AddPhemex(
            this IServiceCollection services,
            Action<PhemexOptions>? optionsDelegate = null)
        {
            var options = new PhemexOptions();
            options.Rest.Environment = null!;
            options.Socket.Environment = null!;
            optionsDelegate?.Invoke(options);
            if (options.Rest == null || options.Socket == null)
                throw new ArgumentException("Options null");

            options.Rest.Environment = options.Rest.Environment ?? options.Environment ?? PhemexEnvironment.Live;
            options.Rest.ApiCredentials = options.Rest.ApiCredentials ?? options.ApiCredentials;
            options.Socket.Environment = options.Socket.Environment ?? options.Environment ?? PhemexEnvironment.Live;
            options.Socket.ApiCredentials = options.Socket.ApiCredentials ?? options.ApiCredentials;

            services.AddSingleton(x => Options.Options.Create(options.Rest));
            services.AddSingleton(x => Options.Options.Create(options.Socket));

            return AddPhemexCore(services, options.SocketClientLifeTime);
        }

        private static IServiceCollection AddPhemexCore(
            this IServiceCollection services,
            ServiceLifetime? socketClientLifeTime = null)
        {
            services.AddHttpClient<IPhemexRestClient, PhemexRestClient>((client, serviceProvider) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<PhemexRestOptions>>().Value;
                client.Timeout = options.RequestTimeout;
                return new PhemexRestClient(client, serviceProvider.GetRequiredService<ILoggerFactory>(), serviceProvider.GetRequiredService<IOptions<PhemexRestOptions>>());
            }).ConfigurePrimaryHttpMessageHandler(serviceProvider =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<PhemexRestOptions>>().Value;
                return LibraryHelpers.CreateHttpClientMessageHandler(options);
            }).SetHandlerLifetime(Timeout.InfiniteTimeSpan);
            services.Add(new ServiceDescriptor(typeof(IPhemexSocketClient), x => new PhemexSocketClient(x.GetRequiredService<IOptions<PhemexSocketOptions>>(), x.GetRequiredService<ILoggerFactory>()), socketClientLifeTime ?? ServiceLifetime.Singleton));

            services.AddSingleton<IPhemexUserClientProvider, PhemexUserClientProvider>(x =>
                new PhemexUserClientProvider(
                    x.GetRequiredService<IHttpClientFactory>().CreateClient(typeof(IPhemexRestClient).Name),
                    x.GetRequiredService<ILoggerFactory>(),
                    x.GetRequiredService<IOptions<PhemexRestOptions>>(),
                    x.GetRequiredService<IOptions<PhemexSocketOptions>>()));

            return services;
        }
    }
}