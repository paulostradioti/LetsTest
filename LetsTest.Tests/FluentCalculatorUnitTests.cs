using System;
using System.Linq;
using LetsTest.Domain;
using Moq;
using Xunit;

namespace LetsTest.Tests
{
    public class FluentCalculatorUnitTests
    {
        private Mock<IInputParser> _parser;
        private FluentCalculator sut;

        public FluentCalculatorUnitTests()
        {
            _parser = new Mock<IInputParser>(MockBehavior.Strict);
            sut = new FluentCalculator(_parser.Object);
        }

        [Fact]
        public void Pow_IfZero_ReturnsZero()
        {
            //Arrange (Arrumar)
            var expected = 0d;

            // Act (Acionar)
            var actual = sut.Pow(5).Result;

            // Assert (Averiguar)
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivideBy_Zero_ReturnsNaN()
        {
            //Arrange (Arrumar)
            var expected = double.NaN;

            // Act (Acionar) && Assert (Averiguar)
            var actual = sut.DivideBy(0).Result;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void DivideBy_NByZero_ReturnsInfinity()
        {
            //Arrange (Arrumar)
            var expected = double.PositiveInfinity;

            // Act (Acionar) && Assert (Averiguar)
            var actual = sut.Plus(10).DivideBy(0).Result;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Minus_NegativeValue_ThrowsException()
        {
            //Arrange
            var expectedMessage = "NEGATIVE NUMBERS";
            Func<double, FluentCalculator> action = sut.Minus;

            //Act && Assert
            var actual = Assert.Throws<ArgumentException>(() => action(-1));


            //Assert
            Assert.Contains(expectedMessage, actual.Message, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void PlusEnumerable_Returns_Sum()
        {
            //Arrange 
            var enumerable = Enumerable.Range(1, 4).Select(x => (double)x);
            _parser.Setup(x => x.Parse("1;2;3;4")).Returns(enumerable);
            var expected = 10d;

            //Act
            var actual = sut.Plus("1;2;3;4").Result;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
