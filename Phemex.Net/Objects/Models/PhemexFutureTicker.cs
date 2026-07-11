using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// USD-margined perpetual ticker entry from the packed 24-hour ticker stream.
    /// </summary>
    [JsonConverter(typeof(ArrayConverter<PhemexFutureTicker>))]
    public record PhemexFutureTicker
    {
        /// <summary>[<c>0</c>] Contract symbol.</summary>
        [ArrayProperty(0)]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>[<c>1</c>] Unscaled 24-hour open price.</summary>
        [ArrayProperty(1)]
        public decimal? OpenPrice { get; set; }

        /// <summary>[<c>2</c>] Unscaled 24-hour high price.</summary>
        [ArrayProperty(2)]
        public decimal? HighPrice { get; set; }

        /// <summary>[<c>3</c>] Unscaled 24-hour low price.</summary>
        [ArrayProperty(3)]
        public decimal? LowPrice { get; set; }

        /// <summary>[<c>4</c>] Unscaled last trade price.</summary>
        [ArrayProperty(4)]
        public decimal? LastPrice { get; set; }

        /// <summary>[<c>5</c>] Unscaled 24-hour trade volume.</summary>
        [ArrayProperty(5)]
        public decimal? Volume { get; set; }

        /// <summary>[<c>6</c>] Unscaled 24-hour turnover.</summary>
        [ArrayProperty(6)]
        public decimal? Turnover { get; set; }

        /// <summary>[<c>7</c>] Unscaled open interest.</summary>
        [ArrayProperty(7)]
        public decimal? OpenInterest { get; set; }

        /// <summary>[<c>8</c>] Unscaled index price.</summary>
        [ArrayProperty(8)]
        public decimal? IndexPrice { get; set; }

        /// <summary>[<c>9</c>] Unscaled mark price.</summary>
        [ArrayProperty(9)]
        public decimal? MarkPrice { get; set; }

        /// <summary>[<c>10</c>] Unscaled funding rate.</summary>
        [ArrayProperty(10)]
        public decimal? FundingRate { get; set; }

        /// <summary>[<c>11</c>] Unscaled predicted funding rate.</summary>
        [ArrayProperty(11)]
        public decimal? PredictedFundingRate { get; set; }

        /// <summary>[<c>12</c>] Best bid price.</summary>
        [ArrayProperty(12)]
        public decimal? BestBidPrice { get; set; }

        /// <summary>[<c>13</c>] Best ask price.</summary>
        [ArrayProperty(13)]
        public decimal? BestAskPrice { get; set; }
    }
}
