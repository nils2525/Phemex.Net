using System.Text.Json.Serialization;
using Phemex.Net.Enums;

namespace Phemex.Net.Objects.Models;

/// <summary>USD-margined perpetual order returned by the trading REST API.</summary>
public record PhemexFuturesOrder
{
    /// <summary>[<c>actionTimeNs</c>] Action Time Ns.</summary>
    [JsonPropertyName("actionTimeNs")]
    public long ActionTimeNs { get; set; }

    /// <summary>[<c>bizError</c>] Business Error.</summary>
    [JsonPropertyName("bizError")]
    public int BusinessError { get; set; }

    /// <summary>[<c>clOrdID</c>] Client Order Id.</summary>
    [JsonPropertyName("clOrdID")]
    public virtual string ClientOrderId { get; set; } = string.Empty;

    /// <summary>[<c>closedPnlRv</c>] Closed Pnl.</summary>
    [JsonPropertyName("closedPnlRv")]
    public decimal ClosedPnl { get; set; }

    /// <summary>[<c>closedSizeRq</c>] Closed Quantity.</summary>
    [JsonPropertyName("closedSizeRq")]
    public decimal ClosedQuantity { get; set; }

    /// <summary>[<c>cumQtyRq</c>] Filled Quantity.</summary>
    [JsonPropertyName("cumQtyRq")]
    public decimal FilledQuantity { get; set; }

    /// <summary>[<c>cumValueRv</c>] Filled Value.</summary>
    [JsonPropertyName("cumValueRv")]
    public decimal FilledValue { get; set; }

    /// <summary>[<c>displayQtyRq</c>] Display Quantity.</summary>
    [JsonPropertyName("displayQtyRq")]
    public decimal DisplayQuantity { get; set; }

    /// <summary>[<c>execInst</c>] Execution Instruction.</summary>
    [JsonPropertyName("execInst")]
    public string ExecutionInstruction { get; set; } = string.Empty;

    /// <summary>[<c>execStatus</c>] Execution Status.</summary>
    [JsonPropertyName("execStatus")]
    public string ExecutionStatus { get; set; } = string.Empty;

    /// <summary>[<c>leavesQtyRq</c>] Remaining Quantity.</summary>
    [JsonPropertyName("leavesQtyRq")]
    public decimal RemainingQuantity { get; set; }

    /// <summary>[<c>leavesValueRv</c>] Remaining Value.</summary>
    [JsonPropertyName("leavesValueRv")]
    public decimal RemainingValue { get; set; }

    /// <summary>[<c>ordStatus</c>] Status.</summary>
    [JsonPropertyName("ordStatus")]
    public PhemexOrderStatus Status { get; set; }

    /// <summary>[<c>orderID</c>] Order Id.</summary>
    [JsonPropertyName("orderID")]
    public virtual string OrderId { get; set; } = string.Empty;

    /// <summary>[<c>orderQtyRq</c>] Quantity.</summary>
    [JsonPropertyName("orderQtyRq")]
    public decimal Quantity { get; set; }

    /// <summary>[<c>orderType</c>] Order Type.</summary>
    [JsonPropertyName("orderType")]
    public virtual string OrderType { get; set; } = string.Empty;

    /// <summary>[<c>pegOffsetValueRp</c>] Peg Offset Value.</summary>
    [JsonPropertyName("pegOffsetValueRp")]
    public decimal PegOffsetValue { get; set; }

    /// <summary>[<c>pegOffsetProportionRr</c>] Peg Offset Proportion.</summary>
    [JsonPropertyName("pegOffsetProportionRr")]
    public decimal PegOffsetProportion { get; set; }

    /// <summary>[<c>pegPriceType</c>] Peg Price Type.</summary>
    [JsonPropertyName("pegPriceType")]
    public string PegPriceType { get; set; } = string.Empty;

    /// <summary>[<c>priceRp</c>] Price.</summary>
    [JsonPropertyName("priceRp")]
    public decimal Price { get; set; }

    /// <summary>[<c>reduceOnly</c>] Reduce Only.</summary>
    [JsonPropertyName("reduceOnly")]
    public bool ReduceOnly { get; set; }

    /// <summary>[<c>side</c>] Side.</summary>
    [JsonPropertyName("side")]
    public PhemexOrderSide Side { get; set; }

    /// <summary>[<c>stopDirection</c>] Stop Direction.</summary>
    [JsonPropertyName("stopDirection")]
    public string StopDirection { get; set; } = string.Empty;

    /// <summary>[<c>stopPxRp</c>] Stop Price.</summary>
    [JsonPropertyName("stopPxRp")]
    public decimal StopPrice { get; set; }

    /// <summary>[<c>symbol</c>] Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>[<c>timeInForce</c>] Time In Force.</summary>
    [JsonPropertyName("timeInForce")]
    public string TimeInForce { get; set; } = string.Empty;

    /// <summary>[<c>transactTimeNs</c>] Transaction Time Ns.</summary>
    [JsonPropertyName("transactTimeNs")]
    public long TransactionTimeNs { get; set; }

    /// <summary>[<c>trigger</c>] Trigger.</summary>
    [JsonPropertyName("trigger")]
    public string Trigger { get; set; } = string.Empty;

    /// <summary>[<c>takeProfitRp</c>] Take Profit.</summary>
    [JsonPropertyName("takeProfitRp")]
    public decimal TakeProfit { get; set; }

    /// <summary>[<c>stopLossRp</c>] Stop Loss.</summary>
    [JsonPropertyName("stopLossRp")]
    public decimal StopLoss { get; set; }

    /// <summary>[<c>posSide</c>] Position Side.</summary>
    [JsonPropertyName("posSide")]
    public string PositionSide { get; set; } = string.Empty;

    /// <summary>[<c>slPxRp</c>] Attached stop-loss price.</summary>
    [JsonPropertyName("slPxRp")]
    public decimal StopLossPrice { get; set; }

    /// <summary>[<c>tpPxRp</c>] Attached take-profit price.</summary>
    [JsonPropertyName("tpPxRp")]
    public decimal TakeProfitPrice { get; set; }
}
