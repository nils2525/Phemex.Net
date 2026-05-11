using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Symbol fee rates
    /// </summary>
    public record PhemexFeeRates
    {
        /// <summary>
        /// ["<c>symbolFeeRates</c>"] Symbol fee rates
        /// </summary>
        [JsonPropertyName("symbolFeeRates")]
        public PhemexFeeRate[] SymbolFeeRates { get; set; } = [];
    }
}
