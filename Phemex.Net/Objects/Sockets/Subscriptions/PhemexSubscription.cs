using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
using Microsoft.Extensions.Logging;
using Phemex.Net.Objects.Sockets;
using System;

namespace Phemex.Net.Objects.Sockets.Subscriptions
{
    /// <inheritdoc />
    internal class PhemexSubscription<T> : Subscription
    {
        private readonly Action<DateTime, string?, T> _handler;
        private readonly object[] _parameters;
        private readonly string _method;
        private readonly string _unsubscribeMethod;
        private readonly object[]? _unsubscribeParameters;

        /// <summary>
        /// ctor
        /// </summary>
        public PhemexSubscription(
            ILogger logger,
            string method,
            string unsubscribeMethod,
            object[] parameters,
            string routeIdentifier,
            string? topicFilter,
            Action<DateTime, string?, T> handler,
            bool auth, object[]? unsubscribeParameters = null) : base(logger, auth)
        {
            _handler = handler;
            _method = method;
            _unsubscribeMethod = unsubscribeMethod;
            _parameters = parameters;
            _unsubscribeParameters = unsubscribeParameters;

            MessageRouter = topicFilter == null
                ? MessageRouter.CreateForEvent<T>(routeIdentifier, DoHandleMessage)
                : MessageRouter.CreateForEvent<T>(routeIdentifier, topicFilter, DoHandleMessage);
        }

        /// <inheritdoc />
        protected override Query? GetSubQuery(SocketConnection connection)
            => new PhemexQuery(new PhemexSocketRequest
            {
                Id = ExchangeHelpers.NextId(),
                Method = _method,
                Parameters = _parameters
            }, Authenticated);

        /// <inheritdoc />
        protected override Query? GetUnsubQuery(SocketConnection connection)
            => new PhemexQuery(new PhemexSocketRequest
            {
                Id = ExchangeHelpers.NextId(),
                Method = _unsubscribeMethod,
                Parameters = _unsubscribeParameters ?? _parameters
            }, Authenticated);

        /// <inheritdoc />
        public CallResult DoHandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, T message)
        {
            _handler.Invoke(receiveTime, originalData, message);
            return CallResult.Ok();
        }
    }
}
