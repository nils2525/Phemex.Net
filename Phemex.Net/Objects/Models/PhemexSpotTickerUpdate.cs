using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Spot ticker socket update
    /// </summary>
    public record PhemexSpotTickerUpdate
    {
        /// <summary>
        /// ["<c>spot_market24h</c>"] Ticker
        /// </summary>
        [JsonPropertyName("spot_market24h")]
        public PhemexTicker Ticker { get; set; } = default!;
        /// <summary>
        /// ["<c>timestamp</c>"] Timestamp in nanoseconds
        /// </summary>
        [JsonPropertyName("timestamp")]
        public long TimestampNanoseconds { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonIgnore]
        public DateTime Timestamp => TimestampNanoseconds == 0 ? default : PhemexExchange.ConvertNanosecondsToDateTime(TimestampNanoseconds);
    }
}