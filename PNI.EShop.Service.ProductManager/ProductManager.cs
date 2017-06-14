using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using PNI.EShop.Core.Product;
using PNI.EShop.Core.Services;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Service.ProductManager
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class ProductManager : StatefulService, IProductManagerService
    {
        private readonly ConcurrentBag<Product> _products;
        private readonly SubscriptionClient _subscriptionClient;

        public ProductManager(StatefulServiceContext context)
            : base(context)
        {
            _products = new ConcurrentBag<Product>(CreateProducts());
            
            _subscriptionClient =
                SubscriptionClient.CreateFromConnectionString(ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"], "productrequests", "dataRequestMessage");

            _subscriptionClient.OnMessageAsync(ReceiveMessageAsync);

        }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new ServiceReplicaListener[0];
        }

        /// <summary>
        /// This is the main entry point for your service replica.
        /// This method executes when this replica of your service becomes primary and has write status.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service replica.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following sample code with your own logic 
            //       or remove this RunAsync override if it's not needed in your service.

            var myDictionary = await this.StateManager.GetOrAddAsync<IReliableDictionary<string, long>>("myDictionary");

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var tx = this.StateManager.CreateTransaction())
                {
                    var result = await myDictionary.TryGetValueAsync(tx, "Counter");

                    ServiceEventSource.Current.ServiceMessage(this.Context, "Current Counter Value: {0}",
                        result.HasValue ? result.Value.ToString() : "Value does not exist.");

                    await myDictionary.AddOrUpdateAsync(tx, "Counter", 0, (key, value) => ++value);

                    // If an exception is thrown before calling CommitAsync, the transaction aborts, all changes are 
                    // discarded, and nothing is saved to the secondary replicas.
                    await tx.CommitAsync();
                }

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }

        [Serializable]
        private class RequestAllDataMessage
        {
            public bool SendAllProducts => true;
        }

        private static Task ReceiveMessageAsync(BrokeredMessage message)
        {
            var body = message.GetBody<string>();

            return Task.FromResult(1);
        }

        public IEnumerable<Product> RetrieveAllProducts()
        {
            return _products.ToArray();
        }

        public Product ProductById(ProductId id)
        {
            return _products.First(p => p.Id == id);
        }

        private static IEnumerable<Product> CreateProducts()
        {
            return new[]
            {
                new Product(
                    new ProductId(Guid.Parse("89707fc0-1493-4899-a062-e37127ec497b")),
                    new StringValue("Black Box"),
                    new StringValue("A simple black box"),
                    new ProductModel(
                        new ColorValue(ColorDefinition.Black),
                        new ModelType(ModelTypeDefinition.Box),
                        new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                        new DateValue(DateTimeOffset.UtcNow)),
                    new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                    new DateValue(DateTimeOffset.UtcNow)),
                new Product(
                    new ProductId(Guid.Parse("5a19ff97-8095-4d43-8d30-26751851a6fe")),
                    new StringValue("White Box"),
                    new StringValue("A simple white box"),
                    new ProductModel(
                        new ColorValue(ColorDefinition.White),
                        new ModelType(ModelTypeDefinition.Box),
                        new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                        new DateValue(DateTimeOffset.UtcNow)),
                    new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                    new DateValue(DateTimeOffset.UtcNow)),
                new Product(
                    new ProductId(Guid.Parse("4b4480b3-e368-4f01-931c-67c52eee914a")),
                    new StringValue("Red Cone"),
                    new StringValue("A simple red cone"),
                    new ProductModel(
                        new ColorValue(ColorDefinition.Red),
                        new ModelType(ModelTypeDefinition.Cone),
                        new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                        new DateValue(DateTimeOffset.UtcNow)),
                    new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                    new DateValue(DateTimeOffset.UtcNow)),
                new Product(
                    new ProductId(Guid.Parse("718e5ba7-b31c-4655-849b-880948d83cba")),
                    new StringValue("Green Sphere"),
                    new StringValue("A simple green sphere"),
                    new ProductModel(
                        new ColorValue(ColorDefinition.Green),
                        new ModelType(ModelTypeDefinition.Sphere),
                        new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                        new DateValue(DateTimeOffset.UtcNow)),
                    new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                    new DateValue(DateTimeOffset.UtcNow)),
                new Product(
                    new ProductId(Guid.Parse("5803710e-92a9-4b08-8788-fccf8a9c8e4a")),
                    new StringValue("Black Box"),
                    new StringValue("A simple black box"),
                    new ProductModel(
                        new ColorValue(ColorDefinition.Red),
                        new ModelType(ModelTypeDefinition.Box),
                        new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                        new DateValue(DateTimeOffset.UtcNow)),
                    new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                    new DateValue(DateTimeOffset.UtcNow))
            };

        }
    }
}
