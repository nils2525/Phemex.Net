using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Enums
{
    /// <summary>
    /// Order side
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PhemexOrderSide>))]
    public enum PhemexOrderSide
    {
        /// <summary>
        /// ["<c>Buy</c>"] Buy
        /// </summary>
        [Map("Buy")]
        Buy,
        /// <summary>
        /// ["<c>Sell</c>"] Sell
        /// </summary>
        [Map("Sell")]
        Sell
    }
}