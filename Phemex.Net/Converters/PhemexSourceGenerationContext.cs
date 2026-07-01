using Phemex.Net.Enums;
using Phemex.Net.Objects.Internal;
using Phemex.Net.Objects.Models;
using Phemex.Net.Objects.Sockets;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using CryptoExchange.Net.Objects;

namespace Phemex.Net.Converters
{
    [JsonSerializable(typeof(PhemexDataResult<PhemexProductData>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexServerTime>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexWallet[]>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexOrder>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexOrder[]>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexRows<PhemexOrder>>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexRows<PhemexOrderTrade>>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexOrderTrade[]>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexDeposit[]>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexWithdrawal[]>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexFundsHistory>))]
    [JsonSerializable(typeof(PhemexDataResult<PhemexFeeRates>))]
    [JsonSerializable(typeof(PhemexMarketResult<PhemexTicker[]>))]
    [JsonSerializable(typeof(PhemexMarketResult<PhemexTicker>))]
    [JsonSerializable(typeof(PhemexMarketResult<PhemexOrderBook>))]
    [JsonSerializable(typeof(PhemexMarketResult<PhemexSpotTradeUpdate>))]
    [JsonSerializable(typeof(PhemexSocketRequest))]
    [JsonSerializable(typeof(PhemexSocketResponse))]
    [JsonSerializable(typeof(PhemexSpotTradeUpdate))]
    [JsonSerializable(typeof(PhemexFutureTradeUpdate))]
    [JsonSerializable(typeof(PhemexSpotTickerUpdate))]
    [JsonSerializable(typeof(PhemexWalletOrderUpdate))]
    [JsonSerializable(typeof(PhemexOrderUpdate))]
    [JsonSerializable(typeof(PhemexWallet))]
    [JsonSerializable(typeof(PhemexOrder))]
    [JsonSerializable(typeof(PhemexOrderTrade))]
    [JsonSerializable(typeof(PhemexDeposit))]
    [JsonSerializable(typeof(PhemexWithdrawal))]
    [JsonSerializable(typeof(PhemexFundsHistory))]
    [JsonSerializable(typeof(PhemexRows<PhemexOrder>))]
    [JsonSerializable(typeof(PhemexRows<PhemexOrderTrade>))]
    [JsonSerializable(typeof(PhemexFundsEntry))]
    [JsonSerializable(typeof(PhemexFeeRates))]
    [JsonSerializable(typeof(PhemexFeeRate))]
    [JsonSerializable(typeof(PhemexTrade))]
    [JsonSerializable(typeof(PhemexFutureTrade))]
    [JsonSerializable(typeof(PhemexOrderBookEntry))]
    [JsonSerializable(typeof(PhemexCurrencyStatus))]
    [JsonSerializable(typeof(PhemexOrderSide))]
    [JsonSerializable(typeof(PhemexOrderStatus))]
    [JsonSerializable(typeof(PhemexOrderType))]
    [JsonSerializable(typeof(PhemexQuantityType))]
    [JsonSerializable(typeof(PhemexTimeInForce))]
    [JsonSerializable(typeof(PhemexProductStatus))]
    [JsonSerializable(typeof(PhemexProductType))]
    [JsonSerializable(typeof(PhemexUpdateType))]
    [JsonSerializable(typeof(JsonElement))]
    [JsonSerializable(typeof(object[]))]
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(string[]))]
    [JsonSerializable(typeof(bool))]
    [JsonSerializable(typeof(bool?))]
    [JsonSerializable(typeof(int))]
    [JsonSerializable(typeof(int?))]
    [JsonSerializable(typeof(long))]
    [JsonSerializable(typeof(long?))]
    [JsonSerializable(typeof(decimal))]
    [JsonSerializable(typeof(decimal?))]
    [JsonSerializable(typeof(DateTime))]
    [JsonSerializable(typeof(DateTime?))]
    [JsonSerializable(typeof(Parameters))]
    internal partial class PhemexSourceGenerationContext : JsonSerializerContext
    {
    }
}
