using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using Phemex.Net.Enums;
using System;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Futures trade
    /// </summary>
    [JsonConverter(typeof(ArrayConverter<PhemexFutureTrade>))]
    public record PhemexFutureTrade
    {
        /// <summary>
        /// ["<c>0</c>"] Timestamp in nanoseconds
        /// </summary>
        [ArrayProperty(0)]
        public long TimestampNanoseconds { get; set; }
        /// <summary>
        /// ["<c>1</c>"] Side
        /// </summary>
        [ArrayProperty(1)]
        public PhemexOrderSide Side { get; set; }
        /// <summary>
        /// ["<c>2</c>"] Price
        /// </summary>
        [ArrayProperty(2)]
        public decimal Price { get; set; }
        /// <summary>
        /// ["<c>3</c>"] Quantity
        /// </summary>
        [ArrayProperty(3)]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonIgnore]
        public DateTime Timestamp => TimestampNanoseconds == 0 ? default : PhemexExchange.ConvertNanosecondsToDateTime(TimestampNanoseconds);
    }
}
