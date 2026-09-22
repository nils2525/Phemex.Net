using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>An unscaled perpetual order-book price and base quantity.</summary>
[JsonConverter(typeof(ArrayConverter<PhemexFuturesBookEntry>))]
public record PhemexFuturesBookEntry
{
    /// <summary>[<c>0</c>] Unscaled quote price.</summary>
    [ArrayProperty(0)]
    public decimal Price { get; set; }
    /// <summary>[<c>1</c>] Unscaled base-asset quantity.</summary>
    [ArrayProperty(1)]
    public decimal Quantity { get; set; }
}
