using Phemex.Net.Enums;
using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Order book snapshot
    /// </summary>
    public record PhemexOrderBook
    {
        /// <summary>
        /// ["<c>book</c>"] Book data
        /// </summary>
        [JsonPropertyName("book")]
        public PhemexBook Book { get; set; } = new PhemexBook();
        /// <summary>
        /// ["<c>depth</c>"] Depth
        /// </summary>
        [JsonPropertyName("depth")]
        public int Depth { get; set; }
        /// <summary>
        /// ["<c>sequence</c>"] Sequence
        /// </summary>
        [JsonPropertyName("sequence")]
        public long Sequence { get; set; }
        /// <summary>
        /// ["<c>timestamp</c>"] Timestamp in nanoseconds
        /// </summary>
        [JsonPropertyName("timestamp")]
        public long TimestampNanoseconds { get; set; }
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>type</c>"] Update type
        /// </summary>
        [JsonPropertyName("type")]
        public PhemexUpdateType Type { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonIgnore]
        public DateTime Timestamp => TimestampNanoseconds == 0 ? default : PhemexExchange.ConvertNanosecondsToDateTime(TimestampNanoseconds);
    }
}