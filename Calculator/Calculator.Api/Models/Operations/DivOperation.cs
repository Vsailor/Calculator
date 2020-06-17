using System;

namespace Calculator.Api.Models.Operations
{
    public class DivOperation : Operation
    {
        public DivOperation(double firstValue, double secondValue) : base(firstValue, secondValue)
        {
            if (secondValue.Equals(0))
                throw new ArgumentException("Second value should not be 0");
        }

        public override double Calculate()
        {
            return FirstValue / SecondValue;
        }
    }
}