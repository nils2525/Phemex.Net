using System.Text.Json.Serialization;
using Phemex.Net.Enums;

namespace Phemex.Net.Objects.Models;

/// <summary>Account-wide USD-margined perpetual snapshot or incremental update.</summary>
public record PhemexFuturesAccountUpdate
{
    /// <summary>[<c>accounts_p</c>] Accounts.</summary>
    [JsonPropertyName("accounts_p")]
    public PhemexFuturesAccountBalanceUpdate[] Accounts { get; set; } = [];

    /// <summary>[<c>orders_p</c>] Orders.</summary>
    [JsonPropertyName("orders_p")]
    public PhemexFuturesOrderUpdate[] Orders { get; set; } = [];

    /// <summary>[<c>positions_p</c>] Positions.</summary>
    [JsonPropertyName("positions_p")]
    public PhemexFuturesPositionUpdate[] Positions { get; set; } = [];

    /// <summary>[<c>sequence</c>] Sequence.</summary>
    [JsonPropertyName("sequence")]
    public long Sequence { get; set; }

    /// <summary>[<c>timestamp</c>] Timestamp Ns.</summary>
    [JsonPropertyName("timestamp")]
    public long TimestampNs { get; set; }

    /// <summary>[<c>type</c>] Type.</summary>
    [JsonPropertyName("type")]
    public PhemexUpdateType Type { get; set; }

    /// <summary>[<c>version</c>] Version.</summary>
    [JsonPropertyName("version")]
    public int Version { get; set; }
}
