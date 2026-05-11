using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models
{
    /// <summary>
    /// Funds history
    /// </summary>
    public record PhemexFundsHistory
    {
        /// <summary>
        /// ["<c>rows</c>"] Rows
        /// </summary>
        [JsonPropertyName("rows")]
        public PhemexFundsEntry[] Rows { get; set; } = [];
    }
}
