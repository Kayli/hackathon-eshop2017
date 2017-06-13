using System;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using PNI.EShop.Web.Models;
using PNI.EShop.Web.Services;

namespace PNI.EShop.Web
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class UI : StatelessService
    {
        public UI(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new WebListenerCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting WebListener on {url}");

                        return new WebHostBuilder().UseWebListener()
                                    .ConfigureServices(
                                        services => services
                                            .AddSingleton<StatelessServiceContext>(serviceContext))
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseStartup<Startup>()
                                    .UseApplicationInsights()
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseUrls(url)
                                    .ConfigureServices(ConfigureServices)
                                    .Build();
                    }))
            };
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Add dependencies
            services.AddSingleton<IProductsService>(new ProductsService(CreateProducts()));
            // Add framework services.
            services.AddMvc();
        }

        private static IEnumerable<ProductViewModel> CreateProducts()
        {
            return new[]
            {
                new ProductViewModel { Id = Guid.Parse("89707fc0-1493-4899-a062-e37127ec497b"), Color = ColorDefinition.Black, Type = ModelTypeDefinition.Box, Name = "Black Box"},
                new ProductViewModel { Id = Guid.Parse("5a19ff97-8095-4d43-8d30-26751851a6fe"), Color = ColorDefinition.White, Type = ModelTypeDefinition.Box, Name = "White Box"},
                new ProductViewModel { Id = Guid.Parse("4b4480b3-e368-4f01-931c-67c52eee914a"), Color = ColorDefinition.Red, Type = ModelTypeDefinition.Cone, Name = "Red Cone"},
                new ProductViewModel { Id = Guid.Parse("718e5ba7-b31c-4655-849b-880948d83cba"), Color = ColorDefinition.Blue, Type = ModelTypeDefinition.Cylinder, Name = "Red Cylinder"},
                new ProductViewModel { Id = Guid.Parse("5803710e-92a9-4b08-8788-fccf8a9c8e4a"), Color = ColorDefinition.Green, Type = ModelTypeDefinition.Sphere, Name = "Green Sphere"},
            };

        }
    }
}
