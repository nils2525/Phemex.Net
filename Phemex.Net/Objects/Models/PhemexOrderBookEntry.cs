using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Order book entry
    /// </summary>
    [JsonConverter(typeof(ArrayConverter<PhemexOrderBookEntry>))]
    public record PhemexOrderBookEntry
    {
        /// <summary>
        /// ["<c>0</c>"] Price, scaled by priceScale
        /// </summary>
        [ArrayProperty(0)]
        public decimal PriceEp { get; set; }
        /// <summary>
        /// ["<c>1</c>"] Quantity, scaled by base currency valueScale
        /// </summary>
        [ArrayProperty(1)]
        public decimal QuantityEv { get; set; }
    }
}