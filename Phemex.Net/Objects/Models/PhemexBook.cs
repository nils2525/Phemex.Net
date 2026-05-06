using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Order book levels
    /// </summary>
    public record PhemexBook
    {
        /// <summary>
        /// ["<c>asks</c>"] Asks
        /// </summary>
        [JsonPropertyName("asks")]
        public PhemexOrderBookEntry[] Asks { get; set; } = [];
        /// <summary>
        /// ["<c>bids</c>"] Bids
        /// </summary>
        [JsonPropertyName("bids")]
        public PhemexOrderBookEntry[] Bids { get; set; } = [];
    }
}