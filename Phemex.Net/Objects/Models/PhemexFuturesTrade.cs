using System.Text.Json.Serialization;
using Phemex.Net.Enums;

namespace Phemex.Net.Objects.Models;

/// <summary>USD-margined perpetual execution history.</summary>
public record PhemexFuturesTrade
{
    /// <summary>[<c>transactTimeNs</c>] Transaction Time Ns.</summary>
    [JsonPropertyName("transactTimeNs")]
    public long TransactionTimeNs { get; set; }

    /// <summary>[<c>symbol</c>] Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>[<c>currency</c>] Currency.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    /// <summary>[<c>action</c>] Action.</summary>
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    /// <summary>[<c>posSide</c>] Position Side.</summary>
    [JsonPropertyName("posSide")]
    public string PositionSide { get; set; } = string.Empty;

    /// <summary>[<c>side</c>] Side.</summary>
    [JsonPropertyName("side")]
    public PhemexOrderSide Side { get; set; }

    /// <summary>[<c>tradeType</c>] Trade Type.</summary>
    [JsonPropertyName("tradeType")]
    public string TradeType { get; set; } = string.Empty;

    /// <summary>[<c>execQtyRq</c>] Quantity.</summary>
    [JsonPropertyName("execQtyRq")]
    public decimal Quantity { get; set; }

    /// <summary>[<c>execPriceRp</c>] Price.</summary>
    [JsonPropertyName("execPriceRp")]
    public decimal Price { get; set; }

    /// <summary>[<c>orderQtyRq</c>] Order Quantity.</summary>
    [JsonPropertyName("orderQtyRq")]
    public decimal OrderQuantity { get; set; }

    /// <summary>[<c>priceRp</c>] Order Price.</summary>
    [JsonPropertyName("priceRp")]
    public decimal OrderPrice { get; set; }

    /// <summary>[<c>execValueRv</c>] Value.</summary>
    [JsonPropertyName("execValueRv")]
    public decimal Value { get; set; }

    /// <summary>[<c>feeRateRr</c>] Fee Rate.</summary>
    [JsonPropertyName("feeRateRr")]
    public decimal FeeRate { get; set; }

    /// <summary>[<c>execFeeRv</c>] Fee.</summary>
    [JsonPropertyName("execFeeRv")]
    public decimal Fee { get; set; }

    /// <summary>[<c>closedSizeRq</c>] Closed Quantity.</summary>
    [JsonPropertyName("closedSizeRq")]
    public decimal ClosedQuantity { get; set; }

    /// <summary>[<c>closedPnlRv</c>] Closed Pnl.</summary>
    [JsonPropertyName("closedPnlRv")]
    public decimal ClosedPnl { get; set; }

    /// <summary>[<c>ordType</c>] Order Type.</summary>
    [JsonPropertyName("ordType")]
    public string OrderType { get; set; } = string.Empty;

    /// <summary>[<c>execID</c>] Execution Id.</summary>
    [JsonPropertyName("execID")]
    public string ExecutionId { get; set; } = string.Empty;

    /// <summary>[<c>orderID</c>] Order Id.</summary>
    [JsonPropertyName("orderID")]
    public string OrderId { get; set; } = string.Empty;

    /// <summary>[<c>clOrdID</c>] Client Order Id.</summary>
    [JsonPropertyName("clOrdID")]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>[<c>execStatus</c>] Execution Status.</summary>
    [JsonPropertyName("execStatus")]
    public string ExecutionStatus { get; set; } = string.Empty;
}
