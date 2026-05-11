using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Internal
{
    internal record PhemexRows<T>
    {
        /// <summary>
        /// ["<c>rows</c>"] Rows
        /// </summary>
        [JsonPropertyName("rows")]
        public T[] Rows { get; set; } = [];
    }
}
