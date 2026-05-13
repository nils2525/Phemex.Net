using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using Phemex.Net.Objects.Models;
using Phemex.Net.Objects.Sockets;
using Phemex.Net.Objects.Sockets.Subscriptions;
using System;
using System.Text.Json;

namespace Phemex.Net.UnitTests
{
    [TestFixture]
    public class PhemexOrderBookSubscriptionTests
    {
        [Test]
        public void GetUnsubQuery_SendsEmptyParams_NotSymbolParams()
        {
            // Phemex's orderbook.unsubscribe only accepts params:[]. Sending the symbol-shaped
            // params used for subscribe results in a silent no-op upstream, leaving the book
            // stream flowing for the closed symbol. Guard against regressing to that shape.
            var sub = new PhemexOrderBookSubscription(
                NullLogger.Instance,
                parameters: ["sNMRUSDT", true],
                topicFilter: "sNMRUSDT",
                handler: (_, _, _) => { });

            var query = sub.CreateUnsubscriptionQuery(null!);

            Assert.That(query, Is.Not.Null);
            var request = (PhemexSocketRequest)query!.Request;
            Assert.That(request.Method, Is.EqualTo("orderbook.unsubscribe"));
            Assert.That(request.Parameters, Is.Empty,
                "orderbook.unsubscribe must be sent with an empty params array per Phemex spec.");
        }

        [Test]
        public void GetSubQuery_PreservesSubscribeParameters()
        {
            var sub = new PhemexOrderBookSubscription(
                NullLogger.Instance,
                parameters: ["sNMRUSDT", true],
                topicFilter: "sNMRUSDT",
                handler: (_, _, _) => { });

            var query = sub.CreateSubscriptionQuery(null!);

            Assert.That(query, Is.Not.Null);
            var request = (PhemexSocketRequest)query!.Request;
            Assert.That(request.Method, Is.EqualTo("orderbook.subscribe"));
            Assert.That(request.Parameters, Is.EqualTo(new object[] { "sNMRUSDT", true }));
        }

        [Test]
        public void UnsubQuery_SerializesWithEmptyParamsArray()
        {
            // End-to-end JSON check: the wire payload Phemex actually receives should be
            // `{"id":N,"method":"orderbook.unsubscribe","params":[]}`.
            var sub = new PhemexOrderBookSubscription(
                NullLogger.Instance,
                parameters: ["sBTCUSDT", true],
                topicFilter: "sBTCUSDT",
                handler: (_, _, _) => { });

            var query = sub.CreateUnsubscriptionQuery(null!);
            var json = JsonSerializer.Serialize(query!.Request);

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            Assert.That(root.GetProperty("method").GetString(), Is.EqualTo("orderbook.unsubscribe"));
            Assert.That(root.GetProperty("params").GetArrayLength(), Is.EqualTo(0));
        }
    }
}
