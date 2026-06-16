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
        /// ["<c>PerpetualV2</c>"] Perpetual V2
        /// </summary>
        [Map("PerpetualV2")]
        PerpetualV2,
        /// <summary>
        /// ["<c>Spot</c>"] Spot
        /// </summary>
        [Map("Spot")]
        Spot
    }
}
