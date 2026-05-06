using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using Phemex.Net.Objects.Internal;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Phemex.Net.Clients.MessageHandlers
{
    internal class PhemexRestMessageHandler : JsonRestMessageHandler
    {
        private readonly ErrorMapping _errorMapping;

        public override JsonSerializerOptions Options { get; } = PhemexExchange._serializerContext;

        public PhemexRestMessageHandler(ErrorMapping errorMapping)
        {
            _errorMapping = errorMapping;
        }

        public override Error? CheckDeserializedResponse<T>(HttpResponseHeaders responseHeaders, T result)
        {
            if (result is PhemexDataResult dataResult)
            {
                if (dataResult.Code == 0)
                    return null;

                var code = dataResult.Code.ToString();
                return new ServerError(code, _errorMapping.GetErrorInfo(code, dataResult.Message));
            }

            if (result is PhemexMarketResult marketResult)
            {
                var error = GetMarketError(marketResult.Error);
                if (error == null)
                    return null;

                return new ServerError(error.Value.Code, _errorMapping.GetErrorInfo(error.Value.Code, error.Value.Message));
            }

            return null;
        }

        public override async ValueTask<Error> ParseErrorResponse(
            int httpStatusCode,
            HttpResponseHeaders responseHeaders,
            Stream responseStream)
        {
            var (error, document) = await GetJsonDocument(responseStream).ConfigureAwait(false);
            if (error != null)
                return error;

            var root = document!.RootElement;
            if (root.TryGetProperty("code", out var codeProp))
            {
                var code = codeProp.ValueKind == JsonValueKind.Number ? codeProp.GetInt32().ToString() : codeProp.GetString() ?? httpStatusCode.ToString();
                var message = root.TryGetProperty("msg", out var msgProp) ? msgProp.GetString() : null;
                return new ServerError(code, _errorMapping.GetErrorInfo(code, message));
            }

            if (root.TryGetProperty("error", out var marketErrorProp))
            {
                var marketError = GetMarketError(marketErrorProp);
                if (marketError != null)
                    return new ServerError(marketError.Value.Code, _errorMapping.GetErrorInfo(marketError.Value.Code, marketError.Value.Message));
            }

            return new ServerError(httpStatusCode.ToString(), _errorMapping.GetErrorInfo(httpStatusCode.ToString(), null));
        }

        private static (string Code, string? Message)? GetMarketError(JsonElement? error)
        {
            if (error == null || error.Value.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined)
                return null;

            if (error.Value.ValueKind == JsonValueKind.String)
            {
                var message = error.Value.GetString();
                return string.IsNullOrWhiteSpace(message) ? null : (message!, message);
            }

            if (error.Value.ValueKind == JsonValueKind.Object)
            {
                var code = error.Value.TryGetProperty("code", out var codeProp)
                    ? codeProp.ValueKind == JsonValueKind.Number ? codeProp.GetInt32().ToString() : codeProp.GetString()
                    : "0";
                var message = error.Value.TryGetProperty("message", out var messageProp) ? messageProp.GetString() : error.Value.ToString();

                return (code ?? "0", message);
            }

            return ("0", error.Value.ToString());
        }
    }
}