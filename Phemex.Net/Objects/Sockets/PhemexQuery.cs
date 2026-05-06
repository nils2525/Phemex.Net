using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
using Phemex.Net.Objects.Sockets;
using System;
using System.Text.Json;

namespace Phemex.Net.Objects.Sockets
{
    internal class PhemexQuery : Query<PhemexSocketResponse>
    {
        public PhemexQuery(PhemexSocketRequest request, bool authenticated, int weight = 1) : base(request, authenticated, weight)
        {
            MessageRouter = MessageRouter.CreateWithoutTopicFilter<PhemexSocketResponse>(request.Id.ToString(), HandleMessage);
        }

        public CallResult<PhemexSocketResponse> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, PhemexSocketResponse message)
        {
            if (message.Error != null && message.Error.Value.ValueKind is not JsonValueKind.Null and not JsonValueKind.Undefined)
                return new CallResult<PhemexSocketResponse>(ParseError(message.Error.Value));

            return new CallResult<PhemexSocketResponse>(message, originalData, null);
        }

        private static ServerError ParseError(JsonElement error)
        {
            if (error.ValueKind == JsonValueKind.Object)
            {
                var code = error.TryGetProperty("code", out var codeProp)
                    ? codeProp.ValueKind == JsonValueKind.Number ? codeProp.GetInt32().ToString() : codeProp.GetString()
                    : "0";
                var message = error.TryGetProperty("message", out var messageProp) ? messageProp.GetString() : error.ToString();

                return new ServerError(code ?? "0", PhemexErrors.SocketErrors.GetErrorInfo(code ?? "0", message));
            }

            var errorMessage = error.ToString();
            return new ServerError("0", PhemexErrors.SocketErrors.GetErrorInfo("0", errorMessage));
        }
    }
}
