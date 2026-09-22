using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>Unscaled USD-margined perpetual depth levels.</summary>
public record PhemexFuturesBook
{
    /// <summary>[<c>asks</c>] Sell levels.</summary>
    [JsonPropertyName("asks")]
    public PhemexFuturesBookEntry[] Asks { get; set; } = [];
    /// <summary>[<c>bids</c>] Buy levels.</summary>
    [JsonPropertyName("bids")]
    public PhemexFuturesBookEntry[] Bids { get; set; } = [];
}
