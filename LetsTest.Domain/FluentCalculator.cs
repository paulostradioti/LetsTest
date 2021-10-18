using System;
using System.Collections.Generic;
using System.Linq;

namespace LetsTest.Domain
{
    public class FluentCalculator
    {
        
        private readonly IInputParser _parser;

        public FluentCalculator(IInputParser parser)
        {

            _parser = parser;
            Result = 0;
        }

        public double Result { get; private set; }

     
        public FluentCalculator Plus(double value)
        {
            Result += value;
            return this;
        }

        public FluentCalculator Plus(string input)
        {
            var inputNumbers = _parser.Parse(input);
            Result += inputNumbers.Sum();

            return this;
        }

        public FluentCalculator Minus(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("negative numbers not allowed", nameof(value));
            }

            Result -= value;
            return this;
        }
        public FluentCalculator MultiplyBy(double value)
        {
            Result *= value;
            return this;
        }

        public FluentCalculator DivideBy(double value)
        {
            Result /= value;
            return this;
        }

        public FluentCalculator Pow(double value)
        {
            Result = Math.Pow(Result, value);
            return this;
        }

        public FluentCalculator Sqrt()
        {
            Result = Math.Sqrt(Result);
            return this;
        }

        public FluentCalculator Reset()
        {
            Result = 0;
            return this;
        }
    }
}