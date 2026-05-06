using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
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
            if (!requestConfig.Authenticated)
                return;

            var expiry = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60;
            var queryString = requestConfig.GetQueryString(false);
            requestConfig.SetQueryString(queryString);

            var signString = requestConfig.Path + queryString + expiry;
            if (requestConfig.BodyParameters != null)
            {
                var body = GetSerializedBody(_messageSerializer, requestConfig.BodyParameters);
                signString += body;
                requestConfig.SetBodyContent(body);
            }

            var signature = SignHMACSHA256(signString, SignOutputType.Hex);

            requestConfig.Headers ??= new Dictionary<string, string>();
            requestConfig.Headers.Add("x-phemex-access-token", Key);
            requestConfig.Headers.Add("x-phemex-request-expiry", expiry.ToString());
            requestConfig.Headers.Add("x-phemex-request-signature", signature);
        }
    }
}