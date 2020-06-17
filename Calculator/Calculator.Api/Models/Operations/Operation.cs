namespace Calculator.Api.Models.Operations
{
    public abstract class Operation
    {
        protected Operation(double firstValue, double secondValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
        }

        protected double FirstValue { get; }

        protected double SecondValue { get; }

        public abstract double Calculate();
    }
}