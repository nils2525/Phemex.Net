using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>Private-stream position; the unrealized PnL field differs in casing from REST.</summary>
public record PhemexFuturesPositionUpdate : PhemexFuturesPosition
{
    /// <summary>[<c>unrealisedPnlRv</c>] Unrealized profit or loss in the settlement asset.</summary>
    [JsonPropertyName("unrealisedPnlRv")]
    public override decimal? UnrealizedPnl { get; set; }

    /// <summary>[<c>crossMarginWeightRv</c>] Cross-margin allocation weight.</summary>
    [JsonPropertyName("crossMarginWeightRv")]
    public decimal CrossMarginWeight { get; set; }

    /// <summary>[<c>curTermDiscountFeeRv</c>] Current-term discounted fees.</summary>
    [JsonPropertyName("curTermDiscountFeeRv")]
    public decimal CurrentTermDiscountFee { get; set; }

    /// <summary>[<c>curTermPtFeeRv</c>] Current-term PT fees.</summary>
    [JsonPropertyName("curTermPtFeeRv")]
    public decimal CurrentTermPtFee { get; set; }

    /// <summary>[<c>riskLimitIndexId</c>] Risk tier identifier.</summary>
    [JsonPropertyName("riskLimitIndexId")]
    public long RiskLimitIndexId { get; set; }
}
