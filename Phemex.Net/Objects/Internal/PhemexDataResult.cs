using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Internal
{
    /// <summary>
    /// Data response
    /// </summary>
    internal record PhemexDataResult
    {
        /// <summary>
        /// ["<c>code</c>"] Response code
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }
        /// <summary>
        /// ["<c>msg</c>"] Message
        /// </summary>
        [JsonPropertyName("msg")]
        public string? Message { get; set; }
    }
}