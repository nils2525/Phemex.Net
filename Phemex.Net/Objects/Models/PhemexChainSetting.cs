using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Public chain setting
    /// </summary>
    public record PhemexChainSetting
    {
        /// <summary>
        /// ["<c>currencyCode</c>"] Asset code
        /// </summary>
        [JsonPropertyName("currencyCode")]
        public int CurrencyCode { get; set; }
        /// <summary>
        /// ["<c>currencyName</c>"] Asset
        /// </summary>
        [JsonPropertyName("currencyName")]
        public string CurrencyName { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>chainName</c>"] Chain name
        /// </summary>
        [JsonPropertyName("chainName")]
        public string ChainName { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>chainTxUrl</c>"] Chain transaction URL
        /// </summary>
        [JsonPropertyName("chainTxUrl")]
        public string? ChainTransactionUrl { get; set; }
        /// <summary>
        /// ["<c>chainId</c>"] Chain id
        /// </summary>
        [JsonPropertyName("chainId")]
        public int ChainId { get; set; }
        /// <summary>
        /// ["<c>displayName</c>"] Display name
        /// </summary>
        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }
        /// <summary>
        /// ["<c>displayNetwork</c>"] Display network
        /// </summary>
        [JsonPropertyName("displayNetwork")]
        public string? DisplayNetwork { get; set; }
        /// <summary>
        /// ["<c>inUse</c>"] Whether the chain is in use
        /// </summary>
        [JsonPropertyName("inUse")]
        public bool InUse { get; set; }
        /// <summary>
        /// ["<c>isMetamask</c>"] Metamask support flag
        /// </summary>
        [JsonPropertyName("isMetamask")]
        public int? IsMetamask { get; set; }
        /// <summary>
        /// ["<c>domainType</c>"] Domain type
        /// </summary>
        [JsonPropertyName("domainType")]
        public int? DomainType { get; set; }
        /// <summary>
        /// ["<c>domainSuffix</c>"] Domain suffix
        /// </summary>
        [JsonPropertyName("domainSuffix")]
        public string? DomainSuffix { get; set; }
        /// <summary>
        /// ["<c>permanentlyClosed</c>"] Permanently closed flag
        /// </summary>
        [JsonPropertyName("permanentlyClosed")]
        public int? PermanentlyClosed { get; set; }
    }
}
