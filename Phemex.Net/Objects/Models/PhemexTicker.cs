using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// 24 hour spot ticker
    /// </summary>
    public record PhemexTicker
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>openEp</c>"] Open price, scaled by priceScale
        /// </summary>
        [JsonPropertyName("openEp")]
        public decimal? OpenPriceEp { get; set; }
        /// <summary>
        /// ["<c>highEp</c>"] High price, scaled by priceScale
        /// </summary>
        [JsonPropertyName("highEp")]
        public decimal? HighPriceEp { get; set; }
        /// <summary>
        /// ["<c>lowEp</c>"] Low price, scaled by priceScale
        /// </summary>
        [JsonPropertyName("lowEp")]
        public decimal? LowPriceEp { get; set; }
        /// <summary>
        /// ["<c>lastEp</c>"] Last price, scaled by priceScale
        /// </summary>
        [JsonPropertyName("lastEp")]
        public decimal? LastPriceEp { get; set; }
        /// <summary>
        /// ["<c>bidEp</c>"] Best bid price, scaled by priceScale
        /// </summary>
        [JsonPropertyName("bidEp")]
        public decimal? BidPriceEp { get; set; }
        /// <summary>
        /// ["<c>askEp</c>"] Best ask price, scaled by priceScale
        /// </summary>
        [JsonPropertyName("askEp")]
        public decimal? AskPriceEp { get; set; }
        /// <summary>
        /// ["<c>turnoverEv</c>"] Turnover, scaled by quote currency valueScale
        /// </summary>
        [JsonPropertyName("turnoverEv")]
        public decimal? TurnoverEv { get; set; }
        /// <summary>
        /// ["<c>volumeEv</c>"] Volume, scaled by base currency valueScale
        /// </summary>
        [JsonPropertyName("volumeEv")]
        public decimal? VolumeEv { get; set; }
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