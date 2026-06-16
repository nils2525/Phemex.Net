using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using Phemex.Net.Objects.Models;
using System.Text.Json;

namespace Phemex.Net.Clients.MessageHandlers
{
    internal class PhemexSocketMessageHandler : JsonSocketMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = PhemexExchange._serializerContext;

        public PhemexSocketMessageHandler()
        {
            AddTopicMapping<PhemexOrderBook>(x => x.Symbol);
            AddTopicMapping<PhemexSpotTradeUpdate>(x => x.Symbol);
            AddTopicMapping<PhemexFutureTradeUpdate>(x => x.Symbol);
        }

        protected override MessageTypeDefinition[] TypeEvaluators { get; } = [
            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("id"),
                ],
                TypeIdentifierCallback = x => x.FieldValue("id")!,
            },
            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("book"),
                ],
                TypeIdentifierCallback = x => "book",
            },
            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("spot_market24h"),
                ],
                TypeIdentifierCallback = x => "spot_market24h",
            },
            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("tick"),
                ],
                TypeIdentifierCallback = x => "tick",
            },
            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("trades"),
                ],
                TypeIdentifierCallback = x => "trades",
            },
            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("trades_p"),
                ],
                TypeIdentifierCallback = x => "trades_p",
            },
            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("wallets"),
                ],
                TypeIdentifierCallback = x => "wallets",
            },
            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("orders"),
                ],
                TypeIdentifierCallback = x => "wallets",
            }
        ];
    }
}
