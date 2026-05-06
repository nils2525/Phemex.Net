using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Enums
{
    /// <summary>
    /// Product status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PhemexProductStatus>))]
    public enum PhemexProductStatus
    {
        /// <summary>
        /// ["<c>Listed</c>"] Listed
        /// </summary>
        [Map("Listed")]
        Listed,
        /// <summary>
        /// ["<c>Delisted</c>"] Delisted
        /// </summary>
        [Map("Delisted")]
        Delisted
    }
}