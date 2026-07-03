using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Deposit chain setting
    /// </summary>
    public record PhemexDepositChainSetting
    {
        /// <summary>
        /// ["<c>currency</c>"] Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>currencyCode</c>"] Asset code
        /// </summary>
        [JsonPropertyName("currencyCode")]
        public int CurrencyCode { get; set; }
        /// <summary>
        /// ["<c>minAmountRv</c>"] Minimum deposit amount
        /// </summary>
        [JsonPropertyName("minAmountRv")]
        public string? MinAmount { get; set; }
        /// <summary>
        /// ["<c>confirmations</c>"] Confirmation height
        /// </summary>
        [JsonPropertyName("confirmations")]
        public long? Confirmations { get; set; }
        /// <summary>
        /// ["<c>chainCode</c>"] Chain code
        /// </summary>
        [JsonPropertyName("chainCode")]
        public int ChainCode { get; set; }
        /// <summary>
        /// ["<c>chainName</c>"] Chain name
        /// </summary>
        [JsonPropertyName("chainName")]
        public string ChainName { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>status</c>"] Status
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        /// <summary>
        /// ["<c>contractAddress</c>"] Contract address
        /// </summary>
        [JsonPropertyName("contractAddress")]
        public string? ContractAddress { get; set; }
    }
}
