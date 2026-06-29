using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting;
using CryptoExchange.Net.RateLimiting.Filters;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.RateLimiting.Interfaces;
using CryptoExchange.Net.SharedApis;
using Phemex.Net.Converters;
using System;
using System.Text.Json;

namespace Phemex.Net
{
    /// <summary>
    /// Phemex exchange information and configuration
    /// </summary>
    public static class PhemexExchange
    {
        /// <summary>
        /// Platform metadata
        /// </summary>
        public static PlatformInfo Metadata { get; } = new PlatformInfo(
                "Phemex",
                "Phemex",
                string.Empty,
                "https://phemex.com/",
                ["https://phemex-docs.github.io/#overview"],
                PlatformType.CryptoCurrencyExchange,
                CentralizationType.Centralized,
                PhemexEnvironment.All
                );

        internal static JsonSerializerOptions _serializerContext = SerializerOptions.WithConverters(JsonSerializerContextCache.GetOrCreate<PhemexSourceGenerationContext>());
        internal static readonly ParameterSerializationSettings _parameterSerializationSettings = new()
        {
            Decimal = DecimalSerialization.String,
            Array = ArrayParametersSerialization.MultipleValues,
            Sort = false
        };

        /// <summary>
        /// Aliases for Phemex assets
        /// </summary>
        public static AssetAliasConfiguration AssetAliases { get; } = new AssetAliasConfiguration
        {
            Aliases = [
                new AssetAlias("USDT", SharedSymbol.UsdOrStable.ToUpperInvariant(), AliasType.OnlyToExchange)
            ]
        };

        /// <summary>
        /// Format a base and quote asset to a Phemex recognized symbol
        /// </summary>
        /// <param name="baseAsset">Base asset</param>
        /// <param name="quoteAsset">Quote asset</param>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="deliverTime">Delivery time for delivery futures</param>
        public static string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
        {
            baseAsset = AssetAliases.CommonToExchangeName(baseAsset.ToUpperInvariant());
            quoteAsset = AssetAliases.CommonToExchangeName(quoteAsset.ToUpperInvariant());

            return tradingMode is TradingMode.Spot ? "s" + baseAsset + quoteAsset : baseAsset + quoteAsset;
        }

        /// <summary>
        /// Scale a Phemex Ep/Ev/Er integer field to decimal using the exchange scale
        /// </summary>
        public static decimal ScaleValue(decimal value, int scale)
        {
            var divisor = 1m;
            for (var i = 0; i < scale; i++)
                divisor *= 10m;

            return value / divisor;
        }

        /// <summary>
        /// Convert a Phemex nanosecond timestamp to UTC DateTime
        /// </summary>
        public static DateTime ConvertNanosecondsToDateTime(long nanoseconds)
            => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddTicks(nanoseconds / 100);

        /// <summary>
        /// Rate limiter configuration for the Phemex API
        /// </summary>
        public static PhemexRateLimiters RateLimiter { get; } = new PhemexRateLimiters();
    }

    /// <summary>
    /// Rate limiter configuration for the Phemex API
    /// </summary>
    public class PhemexRateLimiters
    {
        /// <summary>
        /// Event for when a rate limit is triggered
        /// </summary>
        public event Action<RateLimitEvent>? RateLimitTriggered;
        /// <summary>
        /// Event when the rate limit is updated. Note that it's only updated when a request is send, so there are no specific updates when the current usage is decaying.
        /// </summary>
        public event Action<RateLimitUpdateEvent>? RateLimitUpdated;

        internal PhemexRateLimiters()
        {
            Initialize();
        }

        private void Initialize()
        {
            PhemexRestIp = new RateLimitGate("Phemex IP")
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerHost, new LimitItemTypeFilter(RateLimitItemType.Request), 5000, TimeSpan.FromMinutes(5), RateLimitWindowType.Sliding));
            PhemexSocket = new RateLimitGate("Phemex Socket")
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerHost, new LimitItemTypeFilter(RateLimitItemType.Connection), 200, TimeSpan.FromMinutes(5), RateLimitWindowType.Sliding))
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerConnection, new LimitItemTypeFilter(RateLimitItemType.Request), 20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));

            PhemexRestIp.RateLimitTriggered += x => RateLimitTriggered?.Invoke(x);
            PhemexRestIp.RateLimitUpdated += x => RateLimitUpdated?.Invoke(x);
            PhemexSocket.RateLimitTriggered += x => RateLimitTriggered?.Invoke(x);
            PhemexSocket.RateLimitUpdated += x => RateLimitUpdated?.Invoke(x);
        }

        internal IRateLimitGate PhemexSocket { get; private set; } = null!;
        internal IRateLimitGate PhemexRestIp { get; private set; } = null!;
    }
}
