using System;
using System.Collections.Generic;
using System.Linq;

namespace LetsTest.Domain
{
    public class InputParser : IInputParser
    {
        public IEnumerable<double> Parse(string input)
        {
            var numbers = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

            return (numbers.Length > 0) ? numbers.Select(double.Parse) : Enumerable.Empty<double>();
        }
    }
}