using System;
using System.Threading;
using System.Threading.Tasks;
using LetsTest.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LetsTest.App
{
    public class Program
    {
        private static readonly CancellationTokenSource tokenSource = new();
        static Task Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);
            hostBuilder.ConfigureServices((_, services) =>
            {
                services.AddTransient<IInputParser, InputParser>();
                services.AddTransient<FluentCalculator>();
                services.AddHostedService<Startup>();
                services.AddSingleton(tokenSource);
            });

            using var host = hostBuilder.Build();

            return host.RunAsync(tokenSource.Token);
        }
    }
}
