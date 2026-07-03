using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Withdraw chain settings
    /// </summary>
    public record PhemexWithdrawChainSettings
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
        /// ["<c>balanceRv</c>"] Total balance
        /// </summary>
        [JsonPropertyName("balanceRv")]
        public string? Balance { get; set; }
        /// <summary>
        /// ["<c>confirmAmountRv</c>"] Remaining lifetime amount for non-KYC users
        /// </summary>
        [JsonPropertyName("confirmAmountRv")]
        public string? ConfirmAmount { get; set; }
        /// <summary>
        /// ["<c>allAvailableBalanceRv</c>"] Available withdrawal balance
        /// </summary>
        [JsonPropertyName("allAvailableBalanceRv")]
        public string? AllAvailableBalance { get; set; }
        /// <summary>
        /// ["<c>chainInfos</c>"] Chain info
        /// </summary>
        [JsonPropertyName("chainInfos")]
        public PhemexWithdrawChainInfo[] ChainInfos { get; set; } = [];
    }
}
