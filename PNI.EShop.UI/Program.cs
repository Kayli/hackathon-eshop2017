using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PNI.EShop.Core;
using PNI.EShop.UI.Models;
using PNI.EShop.UI.Services;

namespace PNI.EShop.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .ConfigureServices(ConfigureServices)
                .Build();

            host.Run();
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
                new ProductViewModel { Color = ColorDefinition.Black, Type = ModelTypeDefinition.Box, Name = "Black Box"},
                new ProductViewModel { Color = ColorDefinition.White, Type = ModelTypeDefinition.Box, Name = "White Box"},
                new ProductViewModel { Color = ColorDefinition.Red, Type = ModelTypeDefinition.Cone, Name = "Red Cone"},
                new ProductViewModel { Color = ColorDefinition.Blue, Type = ModelTypeDefinition.Cylinder, Name = "Red Cylinder"},
                new ProductViewModel { Color = ColorDefinition.Green, Type = ModelTypeDefinition.Sphere, Name = "Green Sphere"},
            };

        }
    }
}
