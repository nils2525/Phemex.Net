using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Enums
{
    /// <summary>
    /// Time in force
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PhemexTimeInForce>))]
    public enum PhemexTimeInForce
    {
        /// <summary>
        /// ["<c>GoodTillCancel</c>"] Good till cancel
        /// </summary>
        [Map("GoodTillCancel")]
        GoodTillCancel,
        /// <summary>
        /// ["<c>PostOnly</c>"] Post only
        /// </summary>
        [Map("PostOnly")]
        PostOnly,
        /// <summary>
        /// ["<c>ImmediateOrCancel</c>"] Immediate or cancel
        /// </summary>
        [Map("ImmediateOrCancel")]
        ImmediateOrCancel,
        /// <summary>
        /// ["<c>FillOrKill</c>"] Fill or kill
        /// </summary>
        [Map("FillOrKill")]
        FillOrKill
    }
}
