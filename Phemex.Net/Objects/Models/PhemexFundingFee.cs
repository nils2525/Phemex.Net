using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>One posted USD-margined funding fee, with unscaled amounts and market funding rate.</summary>
public record PhemexFundingFee
{
    /// <summary>[<c>symbol</c>] Contract symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;
    /// <summary>[<c>currency</c>] Settlement asset.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
    /// <summary>[<c>execQtyRq</c>] Position quantity.</summary>
    [JsonPropertyName("execQtyRq")]
    public decimal Quantity { get; set; }
    /// <summary>[<c>side</c>] Position direction.</summary>
    [JsonPropertyName("side")]
    public string Side { get; set; } = string.Empty;
    /// <summary>[<c>execPriceRp</c>] Settlement price.</summary>
    [JsonPropertyName("execPriceRp")]
    public decimal Price { get; set; }
    /// <summary>[<c>execValueRv</c>] Position value.</summary>
    [JsonPropertyName("execValueRv")]
    public decimal Value { get; set; }
    /// <summary>[<c>fundingRateRr</c>] Market funding rate.</summary>
    [JsonPropertyName("fundingRateRr")]
    public decimal FundingRate { get; set; }
    /// <summary>[<c>feeRateRr</c>] Rate charged to this position.</summary>
    [JsonPropertyName("feeRateRr")]
    public decimal FeeRate { get; set; }
    /// <summary>[<c>execFeeRv</c>] Funding fee; positive fees debit the wallet.</summary>
    [JsonPropertyName("execFeeRv")]
    public decimal Fee { get; set; }
    /// <summary>[<c>createTime</c>] Ledger posting time in milliseconds.</summary>
    [JsonPropertyName("createTime")]
    public long CreateTime { get; set; }
}
