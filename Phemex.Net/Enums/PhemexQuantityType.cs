using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Enums
{
    /// <summary>
    /// Quantity type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PhemexQuantityType>))]
    public enum PhemexQuantityType
    {
        /// <summary>
        /// ["<c>ByBase</c>"] Quantity is specified in base asset
        /// </summary>
        [Map("ByBase")]
        ByBase,
        /// <summary>
        /// ["<c>ByQuote</c>"] Quantity is specified in quote asset
        /// </summary>
        [Map("ByQuote")]
        ByQuote
    }
}
