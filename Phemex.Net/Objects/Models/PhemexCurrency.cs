using Phemex.Net.Enums;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Currency info
    /// </summary>
    public record PhemexCurrency
    {
        /// <summary>
        /// ["<c>currency</c>"] Currency code
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>name</c>"] Name
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        /// <summary>
        /// ["<c>code</c>"] Numeric code
        /// </summary>
        [JsonPropertyName("code")]
        public int? Code { get; set; }
        /// <summary>
        /// ["<c>valueScale</c>"] Value scale
        /// </summary>
        [JsonPropertyName("valueScale")]
        public int ValueScale { get; set; }
        /// <summary>
        /// ["<c>minValueEv</c>"] Minimum value, scaled by valueScale
        /// </summary>
        [JsonPropertyName("minValueEv")]
        public decimal? MinValueEv { get; set; }
        /// <summary>
        /// ["<c>maxValueEv</c>"] Maximum value, scaled by valueScale
        /// </summary>
        [JsonPropertyName("maxValueEv")]
        public decimal? MaxValueEv { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Status
        /// </summary>
        [JsonPropertyName("status")]
        public PhemexCurrencyStatus? Status { get; set; }
        /// <summary>
        /// ["<c>displayCurrency</c>"] Display currency
        /// </summary>
        [JsonPropertyName("displayCurrency")]
        public string? DisplayCurrency { get; set; }
        /// <summary>
        /// ["<c>assetsPrecision</c>"] Asset precision
        /// </summary>
        [JsonPropertyName("assetsPrecision")]
        public int? AssetsPrecision { get; set; }
    }
}