using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>USD-margined account and position configuration.</summary>
public record PhemexFuturesAccountPositions
{
    /// <summary>[<c>account</c>] Account.</summary>
    [JsonPropertyName("account")]
    public PhemexFuturesAccount Account { get; set; } = new();

    /// <summary>[<c>positions</c>] Positions.</summary>
    [JsonPropertyName("positions")]
    public PhemexFuturesPosition[] Positions { get; set; } = [];
}
