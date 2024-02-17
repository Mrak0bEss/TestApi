using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Start");

                var host = CreateHostBuilder().Build();

                host.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder().
            ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddUserSecrets<Program>();
                });
            });
    }
}