using System.Text.Json;
using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Sockets
{
    /// <summary>
    /// Socket response
    /// </summary>
    internal record PhemexSocketResponse
    {
        /// <summary>
        /// ["<c>id</c>"] Request id
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }
        /// <summary>
        /// ["<c>error</c>"] Error
        /// </summary>
        [JsonPropertyName("error")]
        public JsonElement? Error { get; set; }
        /// <summary>
        /// ["<c>result</c>"] Result
        /// </summary>
        [JsonPropertyName("result")]
        public JsonElement? Result { get; set; }
    }
}