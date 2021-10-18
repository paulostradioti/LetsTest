using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsTest.Domain
{
    public interface IInputParser
    {
        IEnumerable<double> Parse(string input);
    }
}
