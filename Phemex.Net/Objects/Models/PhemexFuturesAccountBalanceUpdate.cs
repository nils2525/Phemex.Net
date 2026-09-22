using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>Private-stream account balance; the account identifier differs in casing from REST.</summary>
public record PhemexFuturesAccountBalanceUpdate : PhemexFuturesAccount
{
    /// <summary>[<c>accountID</c>] Account identifier.</summary>
    [JsonPropertyName("accountID")]
    public override long AccountId { get; set; }
}
