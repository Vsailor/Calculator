namespace Calculator.Api.Models.Operations
{
    public class SubOperation : Operation
    {
        public SubOperation(double firstValue, double secondValue) : base(firstValue, secondValue)
        {
        }

        public override double Calculate()
        {
            return FirstValue - SecondValue;
        }
    }
}