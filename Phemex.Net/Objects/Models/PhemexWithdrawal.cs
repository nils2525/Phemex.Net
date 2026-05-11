using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Withdrawal
    /// </summary>
    public record PhemexWithdrawal
    {
        /// <summary>
        /// ["<c>txHash</c>"] Transaction hash
        /// </summary>
        [JsonPropertyName("txHash")]
        public string? TransactionHash { get; set; }
        /// <summary>
        /// ["<c>currency</c>"] Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>amountEv</c>"] Amount, scaled by currency valueScale
        /// </summary>
        [JsonPropertyName("amountEv")]
        public decimal AmountEv { get; set; }
        /// <summary>
        /// ["<c>feeEv</c>"] Fee, scaled by currency valueScale
        /// </summary>
        [JsonPropertyName("feeEv")]
        public decimal FeeEv { get; set; }
        /// <summary>
        /// ["<c>address</c>"] Address
        /// </summary>
        [JsonPropertyName("address")]
        public string? Address { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Status
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        /// <summary>
        /// ["<c>withdrawStatus</c>"] Withdrawal status
        /// </summary>
        [JsonPropertyName("withdrawStatus")]
        public string? WithdrawalStatus { get; set; }
        /// <summary>
        /// ["<c>createdAt</c>"] Create time in milliseconds
        /// </summary>
        [JsonPropertyName("createdAt")]
        public long? CreateTimeMilliseconds { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonIgnore]
        public DateTime CreateTime
        {
            get
            {
                var value = CreateTimeMilliseconds.GetValueOrDefault();
                return value == 0 ? default : DateTimeOffset.FromUnixTimeMilliseconds(value).UtcDateTime;
            }
        }
    }
}
