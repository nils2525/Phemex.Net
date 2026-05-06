using Phemex.Net.Enums;
using Phemex.Net.Objects.Internal;
using Phemex.Net.Objects.Models;
using Phemex.Net.Objects.Sockets;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Phemex.Net.Converters
{
    [JsonSerializable(typeof(PhemexDataResult<PhemexProductData>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexServerTime>))]
    [JsonSerializable(typeof(PhemexMarketResult<PhemexTicker[]>))]
    [JsonSerializable(typeof(PhemexMarketResult<PhemexTicker>))]
    [JsonSerializable(typeof(PhemexMarketResult<PhemexOrderBook>))]
    [JsonSerializable(typeof(PhemexMarketResult<PhemexTradeUpdate>))]
    [JsonSerializable(typeof(PhemexSocketRequest))]
    [JsonSerializable(typeof(PhemexSocketResponse))]
    [JsonSerializable(typeof(PhemexTradeUpdate))]
    [JsonSerializable(typeof(PhemexSpotTickerUpdate))]
    [JsonSerializable(typeof(PhemexTrade))]
    [JsonSerializable(typeof(PhemexOrderBookEntry))]
    [JsonSerializable(typeof(PhemexCurrencyStatus))]
    [JsonSerializable(typeof(PhemexOrderSide))]
    [JsonSerializable(typeof(PhemexProductStatus))]
    [JsonSerializable(typeof(PhemexProductType))]
    [JsonSerializable(typeof(PhemexUpdateType))]
    [JsonSerializable(typeof(JsonElement))]
    [JsonSerializable(typeof(object[]))]
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(string[]))]
    [JsonSerializable(typeof(int))]
    [JsonSerializable(typeof(int?))]
    [JsonSerializable(typeof(long))]
    [JsonSerializable(typeof(long?))]
    [JsonSerializable(typeof(decimal))]
    [JsonSerializable(typeof(decimal?))]
    [JsonSerializable(typeof(DateTime))]
    [JsonSerializable(typeof(DateTime?))]
    internal partial class PhemexSourceGenerationContext : JsonSerializerContext
    {
    }
}