using System;
using Calculator.Api.Models.Enums;
using Calculator.Api.Models.Operations;
using Calculator.Api.Models.Requests;

namespace Calculator.Api.Services
{
    public static class CalcOperationFactory
    {
        public static Operation GetOperation(CalculateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            switch (request.Operation)
            {
                case OperationType.Add:
                    return new AddOperation(request.FirstValue, request.SecondValue);
                case OperationType.Sub:
                    return new SubOperation(request.FirstValue, request.SecondValue);
                case OperationType.Div:
                    return new DivOperation(request.FirstValue, request.SecondValue);
                case OperationType.Mult:
                    return new MultOperation(request.FirstValue, request.SecondValue);
                default:
                    throw new ArgumentException("Operation type should be specified");
            }
        }
    }
}