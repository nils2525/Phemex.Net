using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Spot wallet
    /// </summary>
    public record PhemexWallet
    {
        /// <summary>
        /// ["<c>currency</c>"] Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>balanceEv</c>"] Balance, scaled by currency valueScale
        /// </summary>
        [JsonPropertyName("balanceEv")]
        public decimal BalanceEv { get; set; }
        /// <summary>
        /// ["<c>lockedTradingBalanceEv</c>"] Locked trading balance, scaled by currency valueScale
        /// </summary>
        [JsonPropertyName("lockedTradingBalanceEv")]
        public decimal LockedTradingBalanceEv { get; set; }
        /// <summary>
        /// ["<c>lockedWithdrawEv</c>"] Locked withdrawal balance, scaled by currency valueScale
        /// </summary>
        [JsonPropertyName("lockedWithdrawEv")]
        public decimal LockedWithdrawEv { get; set; }
        /// <summary>
        /// ["<c>lastUpdateTimeNs</c>"] Last update time in nanoseconds
        /// </summary>
        [JsonPropertyName("lastUpdateTimeNs")]
        public long LastUpdateTimeNanoseconds { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonIgnore]
        public DateTime LastUpdateTime => LastUpdateTimeNanoseconds == 0 ? default : PhemexExchange.ConvertNanosecondsToDateTime(LastUpdateTimeNanoseconds);
    }
}
