using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>USD-margined perpetual account balances.</summary>
public record PhemexFuturesAccount
{
    /// <summary>[<c>accountBalanceRv</c>] Balance.</summary>
    [JsonPropertyName("accountBalanceRv")]
    public decimal Balance { get; set; }

    /// <summary>[<c>accountId</c>] Account Id.</summary>
    [JsonPropertyName("accountId")]
    public virtual long AccountId { get; set; }

    /// <summary>[<c>bonusBalanceRv</c>] Bonus Balance.</summary>
    [JsonPropertyName("bonusBalanceRv")]
    public decimal BonusBalance { get; set; }

    /// <summary>[<c>currency</c>] Currency.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    /// <summary>[<c>totalUsedBalanceRv</c>] Used Balance.</summary>
    [JsonPropertyName("totalUsedBalanceRv")]
    public decimal UsedBalance { get; set; }

    /// <summary>[<c>userID</c>] User Id.</summary>
    [JsonPropertyName("userID")]
    public long UserId { get; set; }

    /// <summary>[<c>status</c>] Status.</summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>[<c>tradeLevel</c>] Trade Level.</summary>
    [JsonPropertyName("tradeLevel")]
    public int? TradeLevel { get; set; }

    /// <summary>[<c>userMode</c>] Account mode: numeric in REST, a name such as Classic in account updates.</summary>
    [JsonPropertyName("userMode")]
    [JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.NumberStringConverter))]
    public string? UserMode { get; set; }
}
