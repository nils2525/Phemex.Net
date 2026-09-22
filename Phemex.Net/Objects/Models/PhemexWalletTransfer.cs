using System.Text.Json.Serialization;

namespace Phemex.Net.Objects.Models;

/// <summary>Result of a transfer between wallets within an account.</summary>
public record PhemexWalletTransfer
{
    /// <summary>[<c>amountEv</c>] Amount Ev.</summary>
    [JsonPropertyName("amountEv")]
    public long AmountEv { get; set; }

    /// <summary>[<c>currency</c>] Currency.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    /// <summary>[<c>status</c>] Status.</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>[<c>bizCode</c>] Business Code.</summary>
    [JsonPropertyName("bizCode")]
    public int BusinessCode { get; set; }

    /// <summary>[<c>createTime</c>] Create Time.</summary>
    [JsonPropertyName("createTime")]
    public long CreateTime { get; set; }
}
