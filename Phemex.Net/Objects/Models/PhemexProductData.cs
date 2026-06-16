using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Product data
    /// </summary>
    public record PhemexProductData
    {
        /// <summary>
        /// ["<c>currencies</c>"] Currencies
        /// </summary>
        [JsonPropertyName("currencies")]
        public PhemexCurrency[] Currencies { get; set; } = [];
        /// <summary>
        /// ["<c>products</c>"] Products
        /// </summary>
        [JsonPropertyName("products")]
        public PhemexProduct[] Products { get; set; } = [];
        /// <summary>
        /// ["<c>perpProductsV2</c>"] USDT/USDC-margined perpetual products
        /// </summary>
        [JsonPropertyName("perpProductsV2")]
        public PhemexProduct[] PerpProductsV2 { get; set; } = [];
    }
}
