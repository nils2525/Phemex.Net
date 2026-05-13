using CryptoExchange.Net;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Microsoft.Extensions.Logging;
using Phemex.Net.Objects.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Phemex.Net.Objects.Sockets.Subscriptions
{
    /// <summary>
    /// Phemex spot orderbook subscription.
    ///
    /// Per the Phemex spot WebSocket spec, <c>orderbook.unsubscribe</c> only accepts <c>params: []</c>
    /// and unsubscribes ALL active orderbook subscriptions on the connection at once. Sending the
    /// symbol-shaped params used for subscribe results in a silent no-op upstream, leaving the
    /// orderbook stream flowing for the closed symbol. To get per-symbol unsubscribe semantics, we
    /// issue the empty-params bulk unsubscribe and immediately resubscribe any co-resident orderbook
    /// subscriptions that are still meant to be active.
    /// </summary>
    internal class PhemexOrderBookSubscription : PhemexSubscription<PhemexOrderBook>
    {
        public PhemexOrderBookSubscription(
            ILogger logger,
            object[] parameters,
            string topicFilter,
            Action<DateTime, string?, PhemexOrderBook> handler)
            : base(logger, "orderbook.subscribe", "orderbook.unsubscribe", parameters, "book", topicFilter, handler, auth: false)
        {
        }

        /// <inheritdoc />
        protected override Query? GetUnsubQuery(SocketConnection connection)
            => new PhemexQuery(new PhemexSocketRequest
            {
                Id = ExchangeHelpers.NextId(),
                Method = "orderbook.unsubscribe",
                Parameters = []
            }, Authenticated);

        /// <inheritdoc />
        public override void HandleUnsubQueryResponse(SocketConnection connection, object? message)
        {
            base.HandleUnsubQueryResponse(connection, message);

            var survivors = connection.Subscriptions
                .OfType<PhemexOrderBookSubscription>()
                .Where(s => s != this && s.Active)
                .ToArray();

            if (survivors.Length == 0)
                return;

            _logger.LogInformation(
                "[Sckt {SocketId}] orderbook.unsubscribe affects all orderbook subs on the connection; resubscribing {Count} survivor(s)",
                connection.SocketId,
                survivors.Length);

            _ = Task.Run(async () =>
            {
                foreach (var survivor in survivors)
                {
                    try
                    {
                        var resubQuery = survivor.CreateSubscriptionQuery(connection);
                        if (resubQuery == null)
                            continue;

                        var result = await connection.SendAndWaitQueryAsync(resubQuery).ConfigureAwait(false);
                        survivor.HandleSubQueryResponse(connection, resubQuery.Response);
                        if (!result)
                            _logger.LogWarning(
                                "[Sckt {SocketId}] failed to resubscribe orderbook survivor {SubId}: {Error}",
                                connection.SocketId, survivor.Id, result.Error);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex,
                            "[Sckt {SocketId}] exception while resubscribing orderbook survivor {SubId}",
                            connection.SocketId, survivor.Id);
                    }
                }
            });
        }
    }
}
