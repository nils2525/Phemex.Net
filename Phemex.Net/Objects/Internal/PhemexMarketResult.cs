using System.Text.Json;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Internal
{
    /// <summary>
    /// Market data response
    /// </summary>
    internal record PhemexMarketResult
    {
        /// <summary>
        /// ["<c>error</c>"] Error
        /// </summary>
        [JsonPropertyName("error")]
        public JsonElement? Error { get; set; }
        /// <summary>
        /// ["<c>id</c>"] Id
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}