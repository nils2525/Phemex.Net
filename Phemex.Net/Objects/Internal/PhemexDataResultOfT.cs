using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Internal
{
    /// <summary>
    /// Data response
    /// </summary>
    internal record PhemexDataResult<T> : PhemexDataResult
    {
        /// <summary>
        /// ["<c>data</c>"] Data
        /// </summary>
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}