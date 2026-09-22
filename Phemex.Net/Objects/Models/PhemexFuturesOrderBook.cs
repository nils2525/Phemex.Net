using System.Text.Json.Serialization;
using Phemex.Net.Enums;

namespace Phemex.Net.Objects.Models;

/// <summary>USD-margined perpetual order book with unscaled price and quantity levels.</summary>
public record PhemexFuturesOrderBook
{
    /// <summary>[<c>depth</c>] Depth.</summary>
    [JsonPropertyName("depth")]
    public int Depth { get; set; }

    /// <summary>[<c>orderbook_p</c>] Book.</summary>
    [JsonPropertyName("orderbook_p")]
    public PhemexFuturesBook Book { get; set; } = new();

    /// <summary>[<c>sequence</c>] Sequence.</summary>
    [JsonPropertyName("sequence")]
    public long Sequence { get; set; }

    /// <summary>[<c>timestamp</c>] Timestamp Ns.</summary>
    [JsonPropertyName("timestamp")]
    public long TimestampNs { get; set; }

    /// <summary>[<c>symbol</c>] Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>[<c>type</c>] Type.</summary>
    [JsonPropertyName("type")]
    public PhemexUpdateType Type { get; set; }
}
