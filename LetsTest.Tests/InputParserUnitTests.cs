using System;
using System.Collections.Generic;
using System.Linq;
using LetsTest.Domain;
using Xunit;

namespace LetsTest.Tests
{
    public class InputParserUnitTests
    {
        [Fact]
        public void ValidInput_Returns_Numbers()
        {
            //Arrumar
            var parser = new InputParser();
            var expected = Enumerable.Range(1, 3).Select(x => (double)x);

            //Acionar
            var actual = parser.Parse("1;2;3");

            //Averiguar
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EmptyString_Returns_Empty()
        {
            //Arrumar
            var parser = new InputParser();

            //Acionar
            var actual = parser.Parse(";;");

            //Averiguar
            Assert.Empty(actual);
        }


        [Fact]
        public void Null_Returns_Numbers()
        {
            //Arrumar
            var parser = new InputParser();
            Func<string, IEnumerable<double>> method = parser.Parse;

            //Acionar
            var exception = Assert.Throws<NullReferenceException>(() => method(null));

            //Averiguar
            Assert.Contains("object reference", exception.Message, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}