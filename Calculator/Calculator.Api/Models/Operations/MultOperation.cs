namespace Calculator.Api.Models.Operations
{
    public class MultOperation : Operation
    {
        public MultOperation(double firstValue, double secondValue) : base(firstValue, secondValue)
        {
        }

        public override double Calculate()
        {
            return FirstValue * SecondValue;
        }
    }
}