using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>Current per-symbol funding rate and actual settlement schedule.</summary>
public record PhemexFundingRate
{
    /// <summary>[<c>symbol</c>] Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>[<c>fundingInterval</c>] Funding Interval.</summary>
    [JsonPropertyName("fundingInterval")]
    public int FundingInterval { get; set; }

    /// <summary>[<c>toNextfundingInterval</c>] Seconds To Next Funding.</summary>
    [JsonPropertyName("toNextfundingInterval")]
    public int SecondsToNextFunding { get; set; }

    /// <summary>[<c>nextfundingTime</c>] Next Funding Time.</summary>
    [JsonPropertyName("nextfundingTime")]
    public long NextFundingTime { get; set; }

    /// <summary>[<c>fundingRate</c>] Funding Rate.</summary>
    [JsonPropertyName("fundingRate")]
    public decimal FundingRate { get; set; }

    /// <summary>[<c>interestRate</c>] Interest Rate.</summary>
    [JsonPropertyName("interestRate")]
    public decimal InterestRate { get; set; }

    /// <summary>[<c>fundingRateCap</c>] Cap.</summary>
    [JsonPropertyName("fundingRateCap")]
    public decimal Cap { get; set; }

    /// <summary>[<c>fundingRateFloor</c>] Floor.</summary>
    [JsonPropertyName("fundingRateFloor")]
    public decimal Floor { get; set; }
}
