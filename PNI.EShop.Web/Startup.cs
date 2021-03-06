﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using PNI.EShop.Core;
using PNI.EShop.Core.Order;
using PNI.EShop.Core.Audit;
using PNI.EShop.Infrastructure;
using PNI.EShop.Infrastructure.EventStore;
using PNI.EShop.Web.Services;
using OrderService = PNI.EShop.Core.Order.OrderService;
using PNI.EShop.Core.Services;
using PNI.EShop.Core.ProductCatalog;
using PNI.EShop.Infrastructure.Services;

namespace PNI.EShop.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            //configure dependency injection
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IAuditRepository>(new AuditRepository());
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IAuditService, AuditService>();
            services.AddTransient<IProductCatalogService, ProductCatalogService>();
            services.AddSingleton<IEventStore>(new EventStore());

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                ServeUnknownFileTypes = true,
                DefaultContentType = "image/png"
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Products}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "Order",
                    template: "{controller=Order}/{action=Index}/{id?}");
            });

            var eventStore = serviceProvider.GetService<IEventStore>();
            eventStore.Subscribe(() => serviceProvider.GetService<IOrderService>());
            eventStore.Subscribe(() => serviceProvider.GetService<IProductCatalogService>());
            eventStore.Subscribe(() => serviceProvider.GetService<IAuditService>());

            var productCatalogService = serviceProvider.GetService<IProductCatalogService>();
            productCatalogService.CreateProduct(
                name: "red box", 
                description: "a simple red box made of plastic", 
                type: ModelTypeDefinition.Box, 
                color: ColorDefinition.Red,
                price: 9.00m
            );
            productCatalogService.CreateProduct(
                name: "black cylinder",
                description: "a simple black cylinder made of plastic",
                type: ModelTypeDefinition.Cylinder,
                color: ColorDefinition.Black,
                price: 5.47m
            );
            productCatalogService.CreateProduct(
                name: "white box",
                description: "a simple white box made of plastic",
                type: ModelTypeDefinition.Box,
                color: ColorDefinition.White,
                price: 9.5m
            );
        }
    }
}
