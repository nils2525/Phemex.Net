using Phemex.Net.Enums;
using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Packed USD-margined perpetual ticker update containing all listed symbols.
    /// </summary>
    public record PhemexFutureTickerPackUpdate
    {
        /// <summary>[<c>data</c>] Ticker rows in the order described by <see cref="Fields"/>.</summary>
        [JsonPropertyName("data")]
        public PhemexFutureTicker[] Data { get; set; } = [];

        /// <summary>[<c>fields</c>] Field names describing each ticker row.</summary>
        [JsonPropertyName("fields")]
        public string[] Fields { get; set; } = [];

        /// <summary>[<c>method</c>] Update method, normally <c>perp_market24h_pack_p.update</c>.</summary>
        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;

        /// <summary>[<c>timestamp</c>] Update timestamp in nanoseconds.</summary>
        [JsonPropertyName("timestamp")]
        public long TimestampNanoseconds { get; set; }

        /// <summary>[<c>type</c>] Update type.</summary>
        [JsonPropertyName("type")]
        public PhemexUpdateType Type { get; set; }

        /// <summary>Update timestamp.</summary>
        [JsonIgnore]
        public DateTime Timestamp => TimestampNanoseconds == 0
            ? default
            : PhemexExchange.ConvertNanosecondsToDateTime(TimestampNanoseconds);
    }
}
