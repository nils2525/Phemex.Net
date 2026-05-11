using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Enums
{
    /// <summary>
    /// Order type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PhemexOrderType>))]
    public enum PhemexOrderType
    {
        /// <summary>
        /// ["<c>Market</c>"] Market
        /// </summary>
        [Map("Market")]
        Market,
        /// <summary>
        /// ["<c>Limit</c>"] Limit
        /// </summary>
        [Map("Limit")]
        Limit
    }
}
