using Calculator.Api.Models.Enums;

namespace Calculator.Api.Models.Requests
{
    public class CalculateRequest
    {
        public double FirstValue { get; set; }

        public double SecondValue { get; set; }

        public OperationType Operation { get; set; }
    }
}