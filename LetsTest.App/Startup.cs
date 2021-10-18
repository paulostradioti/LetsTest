using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LetsTest.Domain;
using Microsoft.Extensions.Hosting;

namespace LetsTest.App
{
    public class Startup : IHostedService
    {
        private readonly FluentCalculator _calc;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public Startup(FluentCalculator calc, CancellationTokenSource cancellationTokenSource)
        {
            _calc = calc;
            _cancellationTokenSource = cancellationTokenSource;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var result = _calc.Plus(1).Plus(3).Plus(-1).Result;
            Console.WriteLine($"Resultado Esperado (3): {result}");

            _calc.Reset();
            result = _calc.Plus(1).DivideBy(1).MultiplyBy(7).Result;
            Console.WriteLine($"Resultado Esperado (7): {result}");

            _calc.Reset();
            result = _calc.Plus(3).Pow(2).Result;
            Console.WriteLine($"Resultado Esperado (9): {result}");

            _calc.Reset();
            result = _calc.Plus(64).Sqrt().Result;
            Console.WriteLine($"Resultado Esperado (8): {result}");

            
            _cancellationTokenSource.Cancel();
            return;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Parando a aplicação...");
            return;
        }
    }
}
