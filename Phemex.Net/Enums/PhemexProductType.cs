using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Enums
{
    /// <summary>
    /// Product type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PhemexProductType>))]
    public enum PhemexProductType
    {
        /// <summary>
        /// ["<c>Perpetual</c>"] Perpetual
        /// </summary>
        [Map("Perpetual")]
        Perpetual,
        /// <summary>
        /// ["<c>Spot</c>"] Spot
        /// </summary>
        [Map("Spot")]
        Spot
    }
}