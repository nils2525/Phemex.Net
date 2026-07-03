using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Withdraw chain info
    /// </summary>
    public record PhemexWithdrawChainInfo
    {
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
        /// <summary>
        /// ["<c>minWithdrawAmountRv</c>"] Minimum withdrawal amount
        /// </summary>
        [JsonPropertyName("minWithdrawAmountRv")]
        public string? MinWithdrawAmount { get; set; }
        /// <summary>
        /// ["<c>minWithdrawAmountWithFeeRv</c>"] Minimum withdrawal amount including fee
        /// </summary>
        [JsonPropertyName("minWithdrawAmountWithFeeRv")]
        public string? MinWithdrawAmountWithFee { get; set; }
        /// <summary>
        /// ["<c>withdrawFeeRv</c>"] Withdrawal fee
        /// </summary>
        [JsonPropertyName("withdrawFeeRv")]
        public string? WithdrawFee { get; set; }
        /// <summary>
        /// ["<c>receiveAmountRv</c>"] Receive amount
        /// </summary>
        [JsonPropertyName("receiveAmountRv")]
        public string? ReceiveAmount { get; set; }
    }
}
