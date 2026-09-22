using System.Text.Json.Serialization;
using Phemex.Net.Enums;

namespace Phemex.Net.Objects.Models;

/// <summary>USD-margined account stream order and execution event.</summary>
public record PhemexFuturesOrderUpdate
{
    /// <summary>[<c>lastLiquidityInd</c>] Liquidity indicator of the last execution.</summary>
    [JsonPropertyName("lastLiquidityInd")]
    public string LastLiquidityIndicator { get; set; } = string.Empty;

    /// <summary>[<c>posTpSlPattern</c>] Position take-profit and stop-loss pattern.</summary>
    [JsonPropertyName("posTpSlPattern")]
    public string PositionTakeProfitStopLossPattern { get; set; } = string.Empty;

    /// <summary>[<c>actionTimeNs</c>] Action Time Ns.</summary>
    [JsonPropertyName("actionTimeNs")]
    public long ActionTimeNs { get; set; }

    /// <summary>[<c>bizError</c>] Business Error.</summary>
    [JsonPropertyName("bizError")]
    public int BusinessError { get; set; }

    /// <summary>[<c>clOrdID</c>] Client Order Id.</summary>
    [JsonPropertyName("clOrdID")]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>[<c>closedPnlRv</c>] Closed Pnl.</summary>
    [JsonPropertyName("closedPnlRv")]
    public decimal ClosedPnl { get; set; }

    /// <summary>[<c>closedSize</c>] Closed Quantity.</summary>
    [JsonPropertyName("closedSize")]
    public decimal ClosedQuantity { get; set; }

    /// <summary>[<c>cumQty</c>] Filled Quantity.</summary>
    [JsonPropertyName("cumQty")]
    public decimal FilledQuantity { get; set; }

    /// <summary>[<c>cumValueRv</c>] Filled Value.</summary>
    [JsonPropertyName("cumValueRv")]
    public decimal FilledValue { get; set; }

    /// <summary>[<c>displayQty</c>] Display Quantity.</summary>
    [JsonPropertyName("displayQty")]
    public decimal DisplayQuantity { get; set; }

    /// <summary>[<c>execInst</c>] Execution Instruction.</summary>
    [JsonPropertyName("execInst")]
    public string ExecutionInstruction { get; set; } = string.Empty;

    /// <summary>[<c>execStatus</c>] Execution Status.</summary>
    [JsonPropertyName("execStatus")]
    public string ExecutionStatus { get; set; } = string.Empty;

    /// <summary>[<c>leavesQty</c>] Remaining Quantity.</summary>
    [JsonPropertyName("leavesQty")]
    public decimal RemainingQuantity { get; set; }

    /// <summary>[<c>leavesValueRv</c>] Remaining Value.</summary>
    [JsonPropertyName("leavesValueRv")]
    public decimal RemainingValue { get; set; }

    /// <summary>[<c>ordStatus</c>] Status.</summary>
    [JsonPropertyName("ordStatus")]
    public PhemexOrderStatus Status { get; set; }

    /// <summary>[<c>orderID</c>] Order Id.</summary>
    [JsonPropertyName("orderID")]
    public string OrderId { get; set; } = string.Empty;

    /// <summary>[<c>orderQty</c>] Quantity.</summary>
    [JsonPropertyName("orderQty")]
    public decimal Quantity { get; set; }

    /// <summary>[<c>ordType</c>] Order Type.</summary>
    [JsonPropertyName("ordType")]
    public string OrderType { get; set; } = string.Empty;

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

    /// <summary>[<c>accountID</c>] Account Id.</summary>
    [JsonPropertyName("accountID")]
    public long AccountId { get; set; }

    /// <summary>[<c>action</c>] Action.</summary>
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    /// <summary>[<c>actionBy</c>] Action By.</summary>
    [JsonPropertyName("actionBy")]
    public string ActionBy { get; set; } = string.Empty;

    /// <summary>[<c>addedSeq</c>] Added Sequence.</summary>
    [JsonPropertyName("addedSeq")]
    public long AddedSequence { get; set; }

    /// <summary>[<c>apRp</c>] Ask Price.</summary>
    [JsonPropertyName("apRp")]
    public decimal AskPrice { get; set; }

    /// <summary>[<c>bpRp</c>] Bid Price.</summary>
    [JsonPropertyName("bpRp")]
    public decimal BidPrice { get; set; }

    /// <summary>[<c>bonusChangedAmountRv</c>] Bonus Changed Amount.</summary>
    [JsonPropertyName("bonusChangedAmountRv")]
    public decimal BonusChangedAmount { get; set; }

    /// <summary>[<c>code</c>] Code.</summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>[<c>cumFeeRv</c>] Cumulative Fee.</summary>
    [JsonPropertyName("cumFeeRv")]
    public decimal CumulativeFee { get; set; }

    /// <summary>[<c>cumPtFeeRv</c>] Cumulative Pt Fee.</summary>
    [JsonPropertyName("cumPtFeeRv")]
    public decimal CumulativePtFee { get; set; }

    /// <summary>[<c>curAccBalanceRv</c>] Current Account Balance.</summary>
    [JsonPropertyName("curAccBalanceRv")]
    public decimal CurrentAccountBalance { get; set; }

    /// <summary>[<c>curAssignedPosBalanceRv</c>] Current Assigned Balance.</summary>
    [JsonPropertyName("curAssignedPosBalanceRv")]
    public decimal CurrentAssignedBalance { get; set; }

    /// <summary>[<c>curBonusBalanceRv</c>] Current Bonus Balance.</summary>
    [JsonPropertyName("curBonusBalanceRv")]
    public decimal CurrentBonusBalance { get; set; }

    /// <summary>[<c>curLeverageRr</c>] Current Leverage.</summary>
    [JsonPropertyName("curLeverageRr")]
    public decimal CurrentLeverage { get; set; }

    /// <summary>[<c>curPosSide</c>] Current Position Side.</summary>
    [JsonPropertyName("curPosSide")]
    public string CurrentPositionSide { get; set; } = string.Empty;

    /// <summary>[<c>curPosSize</c>] Current Position Quantity.</summary>
    [JsonPropertyName("curPosSize")]
    public decimal CurrentPositionQuantity { get; set; }

    /// <summary>[<c>curPosTerm</c>] Current Position Term.</summary>
    [JsonPropertyName("curPosTerm")]
    public long CurrentPositionTerm { get; set; }

    /// <summary>[<c>curPosValueRv</c>] Current Position Value.</summary>
    [JsonPropertyName("curPosValueRv")]
    public decimal CurrentPositionValue { get; set; }

    /// <summary>[<c>curRiskLimitRv</c>] Current Risk Limit.</summary>
    [JsonPropertyName("curRiskLimitRv")]
    public decimal CurrentRiskLimit { get; set; }

    /// <summary>[<c>currency</c>] Currency.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    /// <summary>[<c>cxlRejReason</c>] Cancel Reject Reason.</summary>
    [JsonPropertyName("cxlRejReason")]
    public int CancelRejectReason { get; set; }

    /// <summary>[<c>execFeeRv</c>] Execution Fee.</summary>
    [JsonPropertyName("execFeeRv")]
    public decimal ExecutionFee { get; set; }

    /// <summary>[<c>execID</c>] Execution Id.</summary>
    [JsonPropertyName("execID")]
    public string ExecutionId { get; set; } = string.Empty;

    /// <summary>[<c>execPriceRp</c>] Execution Price.</summary>
    [JsonPropertyName("execPriceRp")]
    public decimal ExecutionPrice { get; set; }

    /// <summary>[<c>execQty</c>] Execution Quantity.</summary>
    [JsonPropertyName("execQty")]
    public decimal ExecutionQuantity { get; set; }

    /// <summary>[<c>execSeq</c>] Execution Sequence.</summary>
    [JsonPropertyName("execSeq")]
    public long ExecutionSequence { get; set; }

    /// <summary>[<c>execValueRv</c>] Execution Value.</summary>
    [JsonPropertyName("execValueRv")]
    public decimal ExecutionValue { get; set; }

    /// <summary>[<c>feeRateRr</c>] Fee Rate.</summary>
    [JsonPropertyName("feeRateRr")]
    public decimal FeeRate { get; set; }

    /// <summary>[<c>message</c>] Message.</summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>[<c>relatedPosTerm</c>] Related Position Term.</summary>
    [JsonPropertyName("relatedPosTerm")]
    public long RelatedPositionTerm { get; set; }

    /// <summary>[<c>relatedReqNum</c>] Related Request Number.</summary>
    [JsonPropertyName("relatedReqNum")]
    public long RelatedRequestNumber { get; set; }

    /// <summary>[<c>slTrigger</c>] Stop Loss Trigger.</summary>
    [JsonPropertyName("slTrigger")]
    public string StopLossTrigger { get; set; } = string.Empty;

    /// <summary>[<c>tpTrigger</c>] Take Profit Trigger.</summary>
    [JsonPropertyName("tpTrigger")]
    public string TakeProfitTrigger { get; set; } = string.Empty;

    /// <summary>[<c>tradeType</c>] Trade Type.</summary>
    [JsonPropertyName("tradeType")]
    public string TradeType { get; set; } = string.Empty;

    /// <summary>[<c>userID</c>] User Id.</summary>
    [JsonPropertyName("userID")]
    public long UserId { get; set; }

    /// <summary>[<c>cl_req_code</c>] Client Request Code.</summary>
    [JsonPropertyName("cl_req_code")]
    public int ClientRequestCode { get; set; }

    /// <summary>[<c>ptFeeRv</c>] Pt Fee.</summary>
    [JsonPropertyName("ptFeeRv")]
    public decimal PtFee { get; set; }

    /// <summary>[<c>ptPriceRp</c>] Pt Price.</summary>
    [JsonPropertyName("ptPriceRp")]
    public decimal PtPrice { get; set; }

    /// <summary>[<c>slPxRp</c>] Stop Loss Price.</summary>
    [JsonPropertyName("slPxRp")]
    public decimal StopLossPrice { get; set; }

    /// <summary>[<c>slTimeInForce</c>] Stop Loss Time In Force.</summary>
    [JsonPropertyName("slTimeInForce")]
    public string StopLossTimeInForce { get; set; } = string.Empty;

    /// <summary>[<c>tpPxRp</c>] Take Profit Price.</summary>
    [JsonPropertyName("tpPxRp")]
    public decimal TakeProfitPrice { get; set; }

    /// <summary>[<c>tpTimeInForce</c>] Take Profit Time In Force.</summary>
    [JsonPropertyName("tpTimeInForce")]
    public string TakeProfitTimeInForce { get; set; } = string.Empty;
}
