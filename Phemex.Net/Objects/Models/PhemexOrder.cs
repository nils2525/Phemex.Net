using Phemex.Net.Enums;
using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Spot order
    /// </summary>
    public record PhemexOrder
    {
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
        /// ["<c>ordType</c>"] Order type
        /// </summary>
        [JsonPropertyName("ordType")]
        public PhemexOrderType OrderType { get; set; }
        /// <summary>
        /// ["<c>ordStatus</c>"] Order status
        /// </summary>
        [JsonPropertyName("ordStatus")]
        public PhemexOrderStatus Status { get; set; }
        /// <summary>
        /// ["<c>qtyType</c>"] Quantity type
        /// </summary>
        [JsonPropertyName("qtyType")]
        public PhemexQuantityType? QuantityType { get; set; }
        /// <summary>
        /// ["<c>timeInForce</c>"] Time in force
        /// </summary>
        [JsonPropertyName("timeInForce")]
        public PhemexTimeInForce? TimeInForce { get; set; }
        /// <summary>
        /// ["<c>priceEp</c>"] Price, scaled by priceScale
        /// </summary>
        [JsonPropertyName("priceEp")]
        public decimal? PriceEp { get; set; }
        /// <summary>
        /// ["<c>avgPriceEp</c>"] Average price, scaled by priceScale
        /// </summary>
        [JsonPropertyName("avgPriceEp")]
        public decimal? AveragePriceEp { get; set; }
        /// <summary>
        /// ["<c>avgTransactPriceEp</c>"] Average executed price, scaled by priceScale
        /// </summary>
        [JsonPropertyName("avgTransactPriceEp")]
        public decimal? AverageTransactPriceEp { get; set; }
        /// <summary>
        /// ["<c>baseQtyEv</c>"] Base quantity, scaled by base currency valueScale
        /// </summary>
        [JsonPropertyName("baseQtyEv")]
        public decimal? BaseQuantityEv { get; set; }
        /// <summary>
        /// ["<c>quoteQtyEv</c>"] Quote quantity, scaled by quote currency valueScale
        /// </summary>
        [JsonPropertyName("quoteQtyEv")]
        public decimal? QuoteQuantityEv { get; set; }
        /// <summary>
        /// ["<c>cumBaseQtyEv</c>"] Cumulative base quantity, scaled by base currency valueScale
        /// </summary>
        [JsonPropertyName("cumBaseQtyEv")]
        public decimal? CumulativeBaseQuantityEv { get; set; }
        /// <summary>
        /// ["<c>cumBaseValueEv</c>"] Cumulative base quantity, scaled by base currency valueScale
        /// </summary>
        [JsonPropertyName("cumBaseValueEv")]
        public decimal? CumulativeBaseValueEv { get; set; }
        /// <summary>
        /// ["<c>cumQuoteQtyEv</c>"] Cumulative quote quantity, scaled by quote currency valueScale
        /// </summary>
        [JsonPropertyName("cumQuoteQtyEv")]
        public decimal? CumulativeQuoteQuantityEv { get; set; }
        /// <summary>
        /// ["<c>cumQuoteValueEv</c>"] Cumulative quote quantity, scaled by quote currency valueScale
        /// </summary>
        [JsonPropertyName("cumQuoteValueEv")]
        public decimal? CumulativeQuoteValueEv { get; set; }
        /// <summary>
        /// ["<c>leavesBaseQtyEv</c>"] Remaining base quantity, scaled by base currency valueScale
        /// </summary>
        [JsonPropertyName("leavesBaseQtyEv")]
        public decimal? LeavesBaseQuantityEv { get; set; }
        /// <summary>
        /// ["<c>leavesQuoteQtyEv</c>"] Remaining quote quantity, scaled by quote currency valueScale
        /// </summary>
        [JsonPropertyName("leavesQuoteQtyEv")]
        public decimal? LeavesQuoteQuantityEv { get; set; }
        /// <summary>
        /// ["<c>cumFeeEv</c>"] Cumulative fee, scaled by fee currency valueScale
        /// </summary>
        [JsonPropertyName("cumFeeEv")]
        public decimal? CumulativeFeeEv { get; set; }
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
        /// ["<c>createTimeNs</c>"] Create time in nanoseconds
        /// </summary>
        [JsonPropertyName("createTimeNs")]
        public long? CreateTimeNanoseconds { get; set; }
        /// <summary>
        /// ["<c>transactTimeNs</c>"] Transaction time in nanoseconds
        /// </summary>
        [JsonPropertyName("transactTimeNs")]
        public long? TransactionTimeNanoseconds { get; set; }
        /// <summary>
        /// ["<c>bizError</c>"] Business error
        /// </summary>
        [JsonPropertyName("bizError")]
        public int? BusinessError { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonIgnore]
        public DateTime CreateTime
        {
            get
            {
                var value = CreateTimeNanoseconds.GetValueOrDefault();
                return value == 0 ? default : PhemexExchange.ConvertNanosecondsToDateTime(value);
            }
        }
        /// <summary>
        /// Transaction time
        /// </summary>
        [JsonIgnore]
        public DateTime TransactionTime
        {
            get
            {
                var value = TransactionTimeNanoseconds.GetValueOrDefault();
                return value == 0 ? default : PhemexExchange.ConvertNanosecondsToDateTime(value);
            }
        }
    }
}
