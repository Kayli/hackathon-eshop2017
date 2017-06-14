using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PNI.EShop.Core;
using PNI.EShop.Core.Order;
using PNI.EShop.Core.Audit;
using PNI.EShop.Core._Common;
using PNI.EShop.Infrastructure;
using PNI.EShop.Infrastructure.EventStore;

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
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IAuditRepository, AuditRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IAuditService, AuditService>();
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

            app.UseStaticFiles();

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
        }
    }
}
