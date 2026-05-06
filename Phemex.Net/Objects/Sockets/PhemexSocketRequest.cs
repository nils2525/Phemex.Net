using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Sockets
{
    /// <summary>
    /// Socket request
    /// </summary>
    internal record PhemexSocketRequest
    {
        /// <summary>
        /// ["<c>id</c>"] Request id
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }
        /// <summary>
        /// ["<c>method</c>"] Method
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>params</c>"] Parameters
        /// </summary>
        [JsonPropertyName("params")]
        public object[] Parameters { get; set; } = [];
    }
}