namespace Calculator.Api.Models.Operations
{
    public class AddOperation : Operation
    {
        public AddOperation(double firstValue, double secondValue) : base(firstValue, secondValue)
        {
        }

        public override double Calculate()
        {
            return FirstValue + SecondValue;
        }
    }
}