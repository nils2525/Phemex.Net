using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Enums
{
    /// <summary>
    /// Currency status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PhemexCurrencyStatus>))]
    public enum PhemexCurrencyStatus
    {
        /// <summary>
        /// ["<c>Listed</c>"] Listed
        /// </summary>
        [Map("Listed")]
        Listed,
        /// <summary>
        /// ["<c>Active</c>"] Active
        /// </summary>
        [Map("Active")]
        Active,
        /// <summary>
        /// ["<c>Delisted</c>"] Delisted
        /// </summary>
        [Map("Delisted")]
        Delisted,
        /// <summary>
        /// ["<c>Suspend</c>"] Suspended
        /// </summary>
        [Map("Suspend")]
        Suspended
    }
}