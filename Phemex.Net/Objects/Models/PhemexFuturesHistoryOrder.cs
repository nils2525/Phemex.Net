using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>Historical order whose identifiers use different casing from the trading API.</summary>
public record PhemexFuturesHistoryOrder : PhemexFuturesOrder
{
    /// <summary>[<c>orderId</c>] Exchange order identifier.</summary>
    [JsonPropertyName("orderId")]
    public override string OrderId { get; set; } = string.Empty;
    /// <summary>[<c>clOrdId</c>] Client order identifier.</summary>
    [JsonPropertyName("clOrdId")]
    public override string ClientOrderId { get; set; } = string.Empty;
    /// <summary>[<c>ordType</c>] Native order type.</summary>
    [JsonPropertyName("ordType")]
    public override string OrderType { get; set; } = string.Empty;
}
