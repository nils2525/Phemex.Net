using Phemex.Net.Enums;
using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Wallet-order socket update
    /// </summary>
    public record PhemexWalletOrderUpdate
    {
        /// <summary>
        /// ["<c>wallets</c>"] Wallet updates
        /// </summary>
        [JsonPropertyName("wallets")]
        public PhemexWallet[] Wallets { get; set; } = [];
        /// <summary>
        /// ["<c>orders</c>"] Order updates
        /// </summary>
        [JsonPropertyName("orders")]
        public PhemexOrderUpdate Orders { get; set; } = new PhemexOrderUpdate();
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
