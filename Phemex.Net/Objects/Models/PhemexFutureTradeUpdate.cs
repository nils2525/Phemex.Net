using Phemex.Net.Enums;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Futures trade update
    /// </summary>
    public record PhemexFutureTradeUpdate
    {
        /// <summary>
        /// ["<c>sequence</c>"] Sequence
        /// </summary>
        [JsonPropertyName("sequence")]
        public long Sequence { get; set; }
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>trades_p</c>"] Perpetual futures trades
        /// </summary>
        [JsonPropertyName("trades_p")]
        public PhemexFutureTrade[] Trades { get; set; } = [];
        /// <summary>
        /// ["<c>type</c>"] Update type
        /// </summary>
        [JsonPropertyName("type")]
        public PhemexUpdateType Type { get; set; }
    }
}
