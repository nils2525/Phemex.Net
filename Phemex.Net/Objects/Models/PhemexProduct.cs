using Phemex.Net.Enums;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Product info
    /// </summary>
    public record PhemexProduct
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>code</c>"] Product code
        /// </summary>
        [JsonPropertyName("code")]
        public int? Code { get; set; }
        /// <summary>
        /// ["<c>type</c>"] Product type
        /// </summary>
        [JsonPropertyName("type")]
        public PhemexProductType Type { get; set; }
        /// <summary>
        /// ["<c>displaySymbol</c>"] Display symbol
        /// </summary>
        [JsonPropertyName("displaySymbol")]
        public string? DisplaySymbol { get; set; }
        /// <summary>
        /// ["<c>quoteCurrency</c>"] Quote currency
        /// </summary>
        [JsonPropertyName("quoteCurrency")]
        public string QuoteCurrency { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>settleCurrency</c>"] Settlement currency
        /// </summary>
        [JsonPropertyName("settleCurrency")]
        public string SettleCurrency { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>tickSize</c>"] Price tick size display value
        /// </summary>
        [JsonPropertyName("tickSize")]
        [JsonConverter(typeof(NumberStringConverter))]
        public string? TickSize { get; set; }
        /// <summary>
        /// ["<c>priceScale</c>"] Price scale
        /// </summary>
        [JsonPropertyName("priceScale")]
        public int PriceScale { get; set; }
        /// <summary>
        /// ["<c>ratioScale</c>"] Ratio scale
        /// </summary>
        [JsonPropertyName("ratioScale")]
        public int RatioScale { get; set; }
        /// <summary>
        /// ["<c>pricePrecision</c>"] Price precision
        /// </summary>
        [JsonPropertyName("pricePrecision")]
        public int? PricePrecision { get; set; }
        /// <summary>
        /// ["<c>baseCurrency</c>"] Base currency
        /// </summary>
        [JsonPropertyName("baseCurrency")]
        public string BaseCurrency { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>baseTickSize</c>"] Base tick size display value
        /// </summary>
        [JsonPropertyName("baseTickSize")]
        public string? BaseTickSize { get; set; }
        /// <summary>
        /// ["<c>baseTickSizeEv</c>"] Base tick size scaled by base currency valueScale
        /// </summary>
        [JsonPropertyName("baseTickSizeEv")]
        public decimal? BaseTickSizeEv { get; set; }
        /// <summary>
        /// ["<c>quoteTickSize</c>"] Quote tick size display value
        /// </summary>
        [JsonPropertyName("quoteTickSize")]
        public string? QuoteTickSize { get; set; }
        /// <summary>
        /// ["<c>quoteTickSizeEv</c>"] Quote tick size scaled by quote currency valueScale
        /// </summary>
        [JsonPropertyName("quoteTickSizeEv")]
        public decimal? QuoteTickSizeEv { get; set; }
        /// <summary>
        /// ["<c>baseQtyPrecision</c>"] Base quantity precision
        /// </summary>
        [JsonPropertyName("baseQtyPrecision")]
        public int? BaseQtyPrecision { get; set; }
        /// <summary>
        /// ["<c>qtyPrecision</c>"] Quantity precision
        /// </summary>
        [JsonPropertyName("qtyPrecision")]
        public int? QuantityPrecision { get; set; }
        /// <summary>
        /// ["<c>qtyStepSize</c>"] Quantity step size display value
        /// </summary>
        [JsonPropertyName("qtyStepSize")]
        [JsonConverter(typeof(NumberStringConverter))]
        public string? QuantityStepSize { get; set; }
        /// <summary>
        /// ["<c>quoteQtyPrecision</c>"] Quote quantity precision
        /// </summary>
        [JsonPropertyName("quoteQtyPrecision")]
        public int? QuoteQtyPrecision { get; set; }
        /// <summary>
        /// ["<c>minOrderValue</c>"] Minimum order value display value
        /// </summary>
        [JsonPropertyName("minOrderValue")]
        public string? MinOrderValue { get; set; }
        /// <summary>
        /// ["<c>minOrderValueEv</c>"] Minimum order value scaled by quote currency valueScale
        /// </summary>
        [JsonPropertyName("minOrderValueEv")]
        public decimal? MinOrderValueEv { get; set; }
        /// <summary>
        /// ["<c>maxBaseOrderSize</c>"] Maximum base order size display value
        /// </summary>
        [JsonPropertyName("maxBaseOrderSize")]
        public string? MaxBaseOrderSize { get; set; }
        /// <summary>
        /// ["<c>maxBaseOrderSizeEv</c>"] Maximum base order size scaled by base currency valueScale
        /// </summary>
        [JsonPropertyName("maxBaseOrderSizeEv")]
        public decimal? MaxBaseOrderSizeEv { get; set; }
        /// <summary>
        /// ["<c>maxOrderQtyRq</c>"] Maximum order quantity display value
        /// </summary>
        [JsonPropertyName("maxOrderQtyRq")]
        [JsonConverter(typeof(NumberStringConverter))]
        public string? MaxOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>maxOrderValue</c>"] Maximum order value display value
        /// </summary>
        [JsonPropertyName("maxOrderValue")]
        public string? MaxOrderValue { get; set; }
        /// <summary>
        /// ["<c>maxOrderValueEv</c>"] Maximum order value scaled by quote currency valueScale
        /// </summary>
        [JsonPropertyName("maxOrderValueEv")]
        public decimal? MaxOrderValueEv { get; set; }
        /// <summary>
        /// ["<c>description</c>"] Description
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Product status
        /// </summary>
        [JsonPropertyName("status")]
        public PhemexProductStatus Status { get; set; }
        /// <summary>
        /// ["<c>listTime</c>"] List time in milliseconds
        /// </summary>
        [JsonPropertyName("listTime")]
        public long? ListTime { get; set; }
    }
}
