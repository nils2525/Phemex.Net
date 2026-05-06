using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Enums
{
    /// <summary>
    /// Update type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PhemexUpdateType>))]
    public enum PhemexUpdateType
    {
        /// <summary>
        /// ["<c>snapshot</c>"] Snapshot
        /// </summary>
        [Map("snapshot")]
        Snapshot,
        /// <summary>
        /// ["<c>incremental</c>"] Incremental
        /// </summary>
        [Map("incremental")]
        Incremental
    }
}