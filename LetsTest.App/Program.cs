using System;
using LetsTest.Domain;

namespace LetsTest.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var calc = new FluentCalculator();

            var result = calc.Plus(1).Plus(3).Plus(-1).Result;
            Console.WriteLine($"Resultado Esperado (3): {result}");

            calc = new FluentCalculator();
            result = calc.Plus(1).DivideBy(1).MultiplyBy(7).Result;
            Console.WriteLine($"Resultado Esperado (7): {result}");

            calc = new FluentCalculator();
            result = calc.Plus(3).Pow(2).Result;
            Console.WriteLine($"Resultado Esperado (9): {result}");

            calc = new FluentCalculator();
            result = calc.Plus(64).Sqrt().Result;
            Console.WriteLine($"Resultado Esperado (8): {result}");

            Console.ReadKey();
        }
    }
}
