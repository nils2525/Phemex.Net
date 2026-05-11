using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Wallet and order update
    /// </summary>
    public record PhemexOrderUpdate
    {
        /// <summary>
        /// ["<c>open</c>"] Open orders
        /// </summary>
        [JsonPropertyName("open")]
        public PhemexOrder[] Open { get; set; } = [];
        /// <summary>
        /// ["<c>closed</c>"] Closed orders
        /// </summary>
        [JsonPropertyName("closed")]
        public PhemexOrder[] Closed { get; set; } = [];
        /// <summary>
        /// ["<c>fills</c>"] Fills
        /// </summary>
        [JsonPropertyName("fills")]
        public PhemexOrderTrade[] Fills { get; set; } = [];
    }
}
