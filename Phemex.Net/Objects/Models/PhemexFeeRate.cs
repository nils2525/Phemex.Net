using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Symbol fee rate
    /// </summary>
    public record PhemexFeeRate
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>makerFeeRateEr</c>"] Maker fee rate, scaled by ratioScale
        /// </summary>
        [JsonPropertyName("makerFeeRateEr")]
        public decimal MakerFeeRateEr { get; set; }
        /// <summary>
        /// ["<c>takerFeeRateEr</c>"] Taker fee rate, scaled by ratioScale
        /// </summary>
        [JsonPropertyName("takerFeeRateEr")]
        public decimal TakerFeeRateEr { get; set; }
    }
}
