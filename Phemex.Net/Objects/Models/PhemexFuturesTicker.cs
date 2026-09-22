using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>Unscaled USD-margined perpetual REST ticker.</summary>
public record PhemexFuturesTicker
{
    /// <summary>[<c>askRp</c>] Ask Price.</summary>
    [JsonPropertyName("askRp")]
    public decimal AskPrice { get; set; }

    /// <summary>[<c>bidRp</c>] Bid Price.</summary>
    [JsonPropertyName("bidRp")]
    public decimal BidPrice { get; set; }

    /// <summary>[<c>fundingRateRr</c>] Funding Rate.</summary>
    [JsonPropertyName("fundingRateRr")]
    public decimal FundingRate { get; set; }

    /// <summary>[<c>highRp</c>] High Price.</summary>
    [JsonPropertyName("highRp")]
    public decimal HighPrice { get; set; }

    /// <summary>[<c>indexRp</c>] Index Price.</summary>
    [JsonPropertyName("indexRp")]
    public decimal IndexPrice { get; set; }

    /// <summary>[<c>lastRp</c>] Last Price.</summary>
    [JsonPropertyName("lastRp")]
    public decimal LastPrice { get; set; }

    /// <summary>[<c>lowRp</c>] Low Price.</summary>
    [JsonPropertyName("lowRp")]
    public decimal LowPrice { get; set; }

    /// <summary>[<c>markRp</c>] Mark Price.</summary>
    [JsonPropertyName("markRp")]
    public decimal MarkPrice { get; set; }

    /// <summary>[<c>openInterestRv</c>] Open Interest.</summary>
    [JsonPropertyName("openInterestRv")]
    public decimal OpenInterest { get; set; }

    /// <summary>[<c>openRp</c>] Open Price.</summary>
    [JsonPropertyName("openRp")]
    public decimal OpenPrice { get; set; }

    /// <summary>[<c>predFundingRateRr</c>] Predicted Funding Rate.</summary>
    [JsonPropertyName("predFundingRateRr")]
    public decimal PredictedFundingRate { get; set; }

    /// <summary>[<c>symbol</c>] Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>[<c>timestamp</c>] Timestamp Ns.</summary>
    [JsonPropertyName("timestamp")]
    public long TimestampNs { get; set; }

    /// <summary>[<c>turnoverRv</c>] Turnover.</summary>
    [JsonPropertyName("turnoverRv")]
    public decimal Turnover { get; set; }

    /// <summary>[<c>volumeRq</c>] Volume.</summary>
    [JsonPropertyName("volumeRq")]
    public decimal Volume { get; set; }
}
