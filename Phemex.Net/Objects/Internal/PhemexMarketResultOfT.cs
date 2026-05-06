using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Internal
{
    /// <summary>
    /// Market data response
    /// </summary>
    internal record PhemexMarketResult<T> : PhemexMarketResult
    {
        /// <summary>
        /// ["<c>result</c>"] Data
        /// </summary>
        [JsonPropertyName("result")]
        public T? Data { get; set; }
    }
}