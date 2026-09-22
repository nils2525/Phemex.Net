using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>USD-margined perpetual position and configuration; quantities are base-asset units.</summary>
public record PhemexFuturesPosition
{
    /// <summary>[<c>accountID</c>] Account Id.</summary>
    [JsonPropertyName("accountID")]
    public long AccountId { get; set; }

    /// <summary>[<c>assignedPosBalanceRv</c>] Assigned Balance.</summary>
    [JsonPropertyName("assignedPosBalanceRv")]
    public decimal AssignedBalance { get; set; }

    /// <summary>[<c>avgEntryPriceRp</c>] Average Entry Price.</summary>
    [JsonPropertyName("avgEntryPriceRp")]
    public decimal AverageEntryPrice { get; set; }

    /// <summary>[<c>avgEntryPrice</c>] Average Entry Price Value.</summary>
    [JsonPropertyName("avgEntryPrice")]
    public decimal? AverageEntryPriceValue { get; set; }

    /// <summary>[<c>bankruptCommRv</c>] Bankruptcy Commission.</summary>
    [JsonPropertyName("bankruptCommRv")]
    public decimal BankruptcyCommission { get; set; }

    /// <summary>[<c>bankruptPriceRp</c>] Bankruptcy Price.</summary>
    [JsonPropertyName("bankruptPriceRp")]
    public decimal BankruptcyPrice { get; set; }

    /// <summary>[<c>buyValueToCostRr</c>] Buy Value To Cost.</summary>
    [JsonPropertyName("buyValueToCostRr")]
    public decimal BuyValueToCost { get; set; }

    /// <summary>[<c>cumClosedPnlRv</c>] Cumulative Closed Pnl.</summary>
    [JsonPropertyName("cumClosedPnlRv")]
    public decimal CumulativeClosedPnl { get; set; }

    /// <summary>[<c>cumFundingFeeRv</c>] Cumulative Funding Fee.</summary>
    [JsonPropertyName("cumFundingFeeRv")]
    public decimal CumulativeFundingFee { get; set; }

    /// <summary>[<c>cumTransactFeeRv</c>] Cumulative Transaction Fee.</summary>
    [JsonPropertyName("cumTransactFeeRv")]
    public decimal CumulativeTransactionFee { get; set; }

    /// <summary>[<c>curTermRealisedPnlRv</c>] Realized Pnl.</summary>
    [JsonPropertyName("curTermRealisedPnlRv")]
    public decimal RealizedPnl { get; set; }

    /// <summary>[<c>currency</c>] Currency.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    /// <summary>[<c>deleveragePercentileRr</c>] Deleverage Percentile.</summary>
    [JsonPropertyName("deleveragePercentileRr")]
    public decimal DeleveragePercentile { get; set; }

    /// <summary>[<c>estimatedOrdLossRv</c>] Estimated Order Loss.</summary>
    [JsonPropertyName("estimatedOrdLossRv")]
    public decimal EstimatedOrderLoss { get; set; }

    /// <summary>[<c>execSeq</c>] Execution Sequence.</summary>
    [JsonPropertyName("execSeq")]
    public long ExecutionSequence { get; set; }

    /// <summary>[<c>initMarginReqRr</c>] Initial Margin Requirement.</summary>
    [JsonPropertyName("initMarginReqRr")]
    public decimal InitialMarginRequirement { get; set; }

    /// <summary>[<c>lastFundingTimeNs</c>] Last Funding Time Ns.</summary>
    [JsonPropertyName("lastFundingTimeNs")]
    public long LastFundingTimeNs { get; set; }

    /// <summary>[<c>lastTermEndTimeNs</c>] Last Term End Time Ns.</summary>
    [JsonPropertyName("lastTermEndTimeNs")]
    public long LastTermEndTimeNs { get; set; }

    /// <summary>[<c>leverageRr</c>] Leverage.</summary>
    [JsonPropertyName("leverageRr")]
    public decimal Leverage { get; set; }

    /// <summary>[<c>liquidationPriceRp</c>] Liquidation Price.</summary>
    [JsonPropertyName("liquidationPriceRp")]
    public decimal LiquidationPrice { get; set; }

    /// <summary>[<c>maintMarginReqRr</c>] Maintenance Margin Requirement.</summary>
    [JsonPropertyName("maintMarginReqRr")]
    public decimal MaintenanceMarginRequirement { get; set; }

    /// <summary>[<c>makerFeeRateRr</c>] Maker Fee Rate.</summary>
    [JsonPropertyName("makerFeeRateRr")]
    public decimal MakerFeeRate { get; set; }

    /// <summary>[<c>markPriceRp</c>] Mark Price.</summary>
    [JsonPropertyName("markPriceRp")]
    public decimal MarkPrice { get; set; }

    /// <summary>[<c>posCostRv</c>] Position Cost.</summary>
    [JsonPropertyName("posCostRv")]
    public decimal PositionCost { get; set; }

    /// <summary>[<c>posMode</c>] Position Mode.</summary>
    [JsonPropertyName("posMode")]
    public string PositionMode { get; set; } = string.Empty;

    /// <summary>[<c>posSide</c>] Position Side.</summary>
    [JsonPropertyName("posSide")]
    public string PositionSide { get; set; } = string.Empty;

    /// <summary>[<c>positionMarginRv</c>] Position Margin.</summary>
    [JsonPropertyName("positionMarginRv")]
    public decimal PositionMargin { get; set; }

    /// <summary>[<c>positionStatus</c>] Status.</summary>
    [JsonPropertyName("positionStatus")]
    public string Status { get; set; } = string.Empty;

    /// <summary>[<c>riskLimitRv</c>] Risk Limit.</summary>
    [JsonPropertyName("riskLimitRv")]
    public decimal RiskLimit { get; set; }

    /// <summary>[<c>sellValueToCostRr</c>] Sell Value To Cost.</summary>
    [JsonPropertyName("sellValueToCostRr")]
    public decimal SellValueToCost { get; set; }

    /// <summary>[<c>side</c>] Side.</summary>
    [JsonPropertyName("side")]
    public string Side { get; set; } = string.Empty;

    /// <summary>[<c>size</c>] Quantity.</summary>
    [JsonPropertyName("size")]
    public decimal Quantity { get; set; }

    /// <summary>[<c>sizeRq</c>] Quantity Rq.</summary>
    [JsonPropertyName("sizeRq")]
    public decimal? QuantityRq { get; set; }

    /// <summary>[<c>symbol</c>] Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>[<c>takerFeeRateRr</c>] Taker Fee Rate.</summary>
    [JsonPropertyName("takerFeeRateRr")]
    public decimal TakerFeeRate { get; set; }

    /// <summary>[<c>term</c>] Term.</summary>
    [JsonPropertyName("term")]
    public long Term { get; set; }

    /// <summary>[<c>transactTimeNs</c>] Transaction Time Ns.</summary>
    [JsonPropertyName("transactTimeNs")]
    public long TransactionTimeNs { get; set; }

    /// <summary>[<c>usedBalanceRv</c>] Used Balance.</summary>
    [JsonPropertyName("usedBalanceRv")]
    public decimal UsedBalance { get; set; }

    /// <summary>[<c>userID</c>] User Id.</summary>
    [JsonPropertyName("userID")]
    public long UserId { get; set; }

    /// <summary>[<c>valueRv</c>] Value.</summary>
    [JsonPropertyName("valueRv")]
    public decimal Value { get; set; }

    /// <summary>[<c>unRealisedPnlRv</c>] Unrealized Pnl.</summary>
    [JsonPropertyName("unRealisedPnlRv")]
    public virtual decimal? UnrealizedPnl { get; set; }

    /// <summary>[<c>buyLeavesQty</c>] Buy Leaves Quantity.</summary>
    [JsonPropertyName("buyLeavesQty")]
    public decimal BuyLeavesQuantity { get; set; }

    /// <summary>[<c>buyLeavesValueRv</c>] Buy Leaves Value.</summary>
    [JsonPropertyName("buyLeavesValueRv")]
    public decimal BuyLeavesValue { get; set; }

    /// <summary>[<c>createdAtNs</c>] Created At Ns.</summary>
    [JsonPropertyName("createdAtNs")]
    public long CreatedAtNs { get; set; }

    /// <summary>[<c>crossSharedBalanceRv</c>] Cross Shared Balance.</summary>
    [JsonPropertyName("crossSharedBalanceRv")]
    public decimal CrossSharedBalance { get; set; }

    /// <summary>[<c>cumPtFeeRv</c>] Cumulative Pt Fee.</summary>
    [JsonPropertyName("cumPtFeeRv")]
    public decimal CumulativePtFee { get; set; }

    /// <summary>[<c>dataVer</c>] Data Version.</summary>
    [JsonPropertyName("dataVer")]
    public long DataVersion { get; set; }

    /// <summary>[<c>displayLeverageRr</c>] Display Leverage.</summary>
    [JsonPropertyName("displayLeverageRr")]
    public decimal DisplayLeverage { get; set; }

    /// <summary>[<c>freeCostRv</c>] Free Cost.</summary>
    [JsonPropertyName("freeCostRv")]
    public decimal FreeCost { get; set; }

    /// <summary>[<c>freeQty</c>] Free Quantity.</summary>
    [JsonPropertyName("freeQty")]
    public decimal FreeQuantity { get; set; }

    /// <summary>[<c>lastFundingTime</c>] Last Funding Time.</summary>
    [JsonPropertyName("lastFundingTime")]
    public long LastFundingTime { get; set; }

    /// <summary>[<c>lastTermEndTime</c>] Last Term End Time.</summary>
    [JsonPropertyName("lastTermEndTime")]
    public long LastTermEndTime { get; set; }

    /// <summary>[<c>minPosCostRv</c>] Minimum Position Cost.</summary>
    [JsonPropertyName("minPosCostRv")]
    public decimal MinimumPositionCost { get; set; }

    /// <summary>[<c>orderCostRv</c>] Order Cost.</summary>
    [JsonPropertyName("orderCostRv")]
    public decimal OrderCost { get; set; }

    /// <summary>[<c>sellLeavesQty</c>] Sell Leaves Quantity.</summary>
    [JsonPropertyName("sellLeavesQty")]
    public decimal SellLeavesQuantity { get; set; }

    /// <summary>[<c>sellLeavesValueRv</c>] Sell Leaves Value.</summary>
    [JsonPropertyName("sellLeavesValueRv")]
    public decimal SellLeavesValue { get; set; }

    /// <summary>[<c>updatedAtNs</c>] Updated At Ns.</summary>
    [JsonPropertyName("updatedAtNs")]
    public long UpdatedAtNs { get; set; }

    /// <summary>[<c>crossMargin</c>] Cross Margin.</summary>
    [JsonPropertyName("crossMargin")]
    public bool? CrossMargin { get; set; }

    /// <summary>[<c>markValueEv</c>] Mark Value Ev.</summary>
    [JsonPropertyName("markValueEv")]
    public decimal MarkValueEv { get; set; }

    /// <summary>[<c>unRealisedPosLossEv</c>] Unrealized Position Loss Ev.</summary>
    [JsonPropertyName("unRealisedPosLossEv")]
    public decimal UnrealizedPositionLossEv { get; set; }

    /// <summary>[<c>takeProfitEp</c>] Take Profit Ep.</summary>
    [JsonPropertyName("takeProfitEp")]
    public decimal TakeProfitEp { get; set; }

    /// <summary>[<c>stopLossEp</c>] Stop Loss Ep.</summary>
    [JsonPropertyName("stopLossEp")]
    public decimal StopLossEp { get; set; }

    /// <summary>[<c>realisedPnlEv</c>] Realized Pnl Ev.</summary>
    [JsonPropertyName("realisedPnlEv")]
    public decimal RealizedPnlEv { get; set; }

    /// <summary>[<c>cumRealisedPnlEv</c>] Cumulative Realized Pnl Ev.</summary>
    [JsonPropertyName("cumRealisedPnlEv")]
    public decimal CumulativeRealizedPnlEv { get; set; }

    /// <summary>[<c>buyLeavesQtyRq</c>] Unfilled buy quantity in base units.</summary>
    [JsonPropertyName("buyLeavesQtyRq")]
    public decimal? BuyLeavesQuantityRq { get; set; }

    /// <summary>[<c>sellLeavesQtyRq</c>] Unfilled sell quantity in base units.</summary>
    [JsonPropertyName("sellLeavesQtyRq")]
    public decimal? SellLeavesQuantityRq { get; set; }
}
