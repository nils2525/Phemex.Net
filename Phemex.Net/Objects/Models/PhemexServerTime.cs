using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Server time
    /// </summary>
    public record PhemexServerTime
    {
        /// <summary>
        /// ["<c>serverTime</c>"] Server time in milliseconds
        /// </summary>
        [JsonPropertyName("serverTime")]
        public long ServerTimeMilliseconds { get; set; }
        /// <summary>
        /// Server time
        /// </summary>
        [JsonIgnore]
        public DateTime ServerTime => DateTimeOffset.FromUnixTimeMilliseconds(ServerTimeMilliseconds).UtcDateTime;
    }
}