using CryptoExchange.Net.Authentication;
using CryptoExchange.Net;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Phemex.Net.Objects.Sockets;
using System;
using System.Collections.Generic;

namespace Phemex.Net
{
    internal class PhemexAuthenticationProvider : AuthenticationProvider<PhemexCredentials, PhemexCredentials>
    {
        private static readonly IStringMessageSerializer _messageSerializer =
            new SystemTextJsonMessageSerializer(PhemexExchange._serializerContext);

        public PhemexAuthenticationProvider(PhemexCredentials credentials) : base(credentials, credentials)
        {
        }

        public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration requestConfig)
        {
            if (!requestConfig.RequestDefinition.Authenticated)
                return;

            var expiry = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60;
            var queryString = requestConfig.GetQueryString(false);
            requestConfig.SetQueryString(queryString);

            var signString = requestConfig.RequestDefinition.Path + queryString + expiry;
            if (requestConfig.BodyParameters != null)
            {
                var body = GetSerializedBody(_messageSerializer, requestConfig.BodyParameters);
                signString += body;
                requestConfig.SetBodyContent(body);
            }

            var signature = SignHMACSHA256(signString, SignOutputType.Hex).ToLowerInvariant();

            requestConfig.Headers ??= new Dictionary<string, string>();
            requestConfig.Headers.Add("x-phemex-access-token", Key);
            requestConfig.Headers.Add("x-phemex-request-expiry", expiry.ToString());
            requestConfig.Headers.Add("x-phemex-request-signature", signature);
        }

        public override Query? GetAuthenticationQuery(SocketApiClient apiClient, SocketConnection connection, Dictionary<string, object?>? context = null)
        {
            var expiry = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60;
            var signature = SignHMACSHA256(Key + expiry, SignOutputType.Hex).ToLowerInvariant();
            return new PhemexQuery(new PhemexSocketRequest
            {
                Id = ExchangeHelpers.NextId(),
                Method = "user.auth",
                Parameters = ["API", Key, signature, expiry]
            }, false);
        }
    }
}
