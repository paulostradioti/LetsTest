using System.Collections.Generic;
using System.Linq;

namespace LetsTest.Domain
{
    public class InputParser : IInputParser
    {
        public IEnumerable<double> Parse(string input)
        {
            return Enumerable.Empty<double>();
        }
    }
}