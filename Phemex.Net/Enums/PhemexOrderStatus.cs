using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Enums
{
    /// <summary>
    /// Order status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PhemexOrderStatus>))]
    public enum PhemexOrderStatus
    {
        /// <summary>
        /// ["<c>Created</c>"] Created
        /// </summary>
        [Map("Created")]
        Created,
        /// <summary>
        /// ["<c>Untriggered</c>"] Conditional order waiting to be triggered
        /// </summary>
        [Map("Untriggered")]
        Untriggered,
        /// <summary>
        /// ["<c>Triggered</c>"] Conditional order triggered
        /// </summary>
        [Map("Triggered")]
        Triggered,
        /// <summary>
        /// ["<c>Rejected</c>"] Rejected
        /// </summary>
        [Map("Rejected")]
        Rejected,
        /// <summary>
        /// ["<c>New</c>"] New
        /// </summary>
        [Map("New")]
        New,
        /// <summary>
        /// ["<c>PartiallyFilled</c>"] Partially filled
        /// </summary>
        [Map("PartiallyFilled")]
        PartiallyFilled,
        /// <summary>
        /// ["<c>Filled</c>"] Filled
        /// </summary>
        [Map("Filled")]
        Filled,
        /// <summary>
        /// ["<c>Canceled</c>"] Canceled
        /// </summary>
        [Map("Canceled", "Cancelled")]
        Canceled
    }
}
