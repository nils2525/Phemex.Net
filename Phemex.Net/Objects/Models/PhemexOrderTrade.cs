using Phemex.Net.Enums;
using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Spot user trade
    /// </summary>
    public record PhemexOrderTrade
    {
        /// <summary>
        /// ["<c>execId</c>"] Execution id
        /// </summary>
        [JsonPropertyName("execId")]
        public string? ExecutionId { get; set; }
        /// <summary>
        /// ["<c>execID</c>"] Execution id
        /// </summary>
        [JsonPropertyName("execID")]
        public string? ExecutionIdUpper { get => ExecutionId; set => ExecutionId = value; }
        /// <summary>
        /// ["<c>orderID</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderID")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>clOrdID</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clOrdID")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>side</c>"] Side
        /// </summary>
        [JsonPropertyName("side")]
        public PhemexOrderSide Side { get; set; }
        /// <summary>
        /// ["<c>execPriceEp</c>"] Execution price, scaled by priceScale
        /// </summary>
        [JsonPropertyName("execPriceEp")]
        public decimal ExecutionPriceEp { get; set; }
        /// <summary>
        /// ["<c>execBaseQtyEv</c>"] Execution base quantity, scaled by base currency valueScale
        /// </summary>
        [JsonPropertyName("execBaseQtyEv")]
        public decimal ExecutionBaseQuantityEv { get; set; }
        /// <summary>
        /// ["<c>execQuoteQtyEv</c>"] Execution quote quantity, scaled by quote currency valueScale
        /// </summary>
        [JsonPropertyName("execQuoteQtyEv")]
        public decimal ExecutionQuoteQuantityEv { get; set; }
        /// <summary>
        /// ["<c>execFeeEv</c>"] Execution fee, scaled by fee currency valueScale
        /// </summary>
        [JsonPropertyName("execFeeEv")]
        public decimal ExecutionFeeEv { get; set; }
        /// <summary>
        /// ["<c>feeCurrency</c>"] Fee currency
        /// </summary>
        [JsonPropertyName("feeCurrency")]
        public string? FeeCurrency { get; set; }
        /// <summary>
        /// ["<c>baseCurrency</c>"] Base currency
        /// </summary>
        [JsonPropertyName("baseCurrency")]
        public string? BaseCurrency { get; set; }
        /// <summary>
        /// ["<c>quoteCurrency</c>"] Quote currency
        /// </summary>
        [JsonPropertyName("quoteCurrency")]
        public string? QuoteCurrency { get; set; }
        /// <summary>
        /// ["<c>lastLiquidityInd</c>"] Liquidity indicator
        /// </summary>
        [JsonPropertyName("lastLiquidityInd")]
        public string? LastLiquidityIndicator { get; set; }
        /// <summary>
        /// ["<c>transactTimeNs</c>"] Transaction time in nanoseconds
        /// </summary>
        [JsonPropertyName("transactTimeNs")]
        public long TransactionTimeNanoseconds { get; set; }
        /// <summary>
        /// Transaction time
        /// </summary>
        [JsonIgnore]
        public DateTime TransactionTime => TransactionTimeNanoseconds == 0 ? default : PhemexExchange.ConvertNanosecondsToDateTime(TransactionTimeNanoseconds);
    }
}
