using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Funds history entry
    /// </summary>
    public record PhemexFundsEntry
    {
        /// <summary>
        /// ["<c>id</c>"] Id
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }
        /// <summary>
        /// ["<c>currency</c>"] Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>execId</c>"] Execution id
        /// </summary>
        [JsonPropertyName("execId")]
        public string? ExecutionId { get; set; }
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
        /// ["<c>side</c>"] Side
        /// </summary>
        [JsonPropertyName("side")]
        public string? Side { get; set; }
        /// <summary>
        /// ["<c>action</c>"] Action
        /// </summary>
        [JsonPropertyName("action")]
        public string? Action { get; set; }
        /// <summary>
        /// ["<c>balanceEv</c>"] Balance, scaled by currency valueScale
        /// </summary>
        [JsonPropertyName("balanceEv")]
        public decimal BalanceEv { get; set; }
        /// <summary>
        /// ["<c>transactTimeNs</c>"] Transaction time in nanoseconds
        /// </summary>
        [JsonPropertyName("transactTimeNs")]
        public long TransactionTimeNanoseconds { get; set; }
        /// <summary>
        /// ["<c>text</c>"] Text
        /// </summary>
        [JsonPropertyName("text")]
        public string? Text { get; set; }
        /// <summary>
        /// ["<c>createTime</c>"] Create time in milliseconds
        /// </summary>
        [JsonPropertyName("createTime")]
        public long? CreateTimeMilliseconds { get; set; }
        /// <summary>
        /// Transaction time
        /// </summary>
        [JsonIgnore]
        public DateTime TransactionTime => TransactionTimeNanoseconds == 0 ? default : PhemexExchange.ConvertNanosecondsToDateTime(TransactionTimeNanoseconds);
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
