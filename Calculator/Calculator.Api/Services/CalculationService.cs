using System.Threading.Tasks;
using Calculator.Api.Models.Operations;
using Calculator.Api.Models.Responses;
using Calculator.Api.Services.Abstracts;

namespace Calculator.Api.Services
{
    public class CalculationService : ICalculationService
    {
        public async Task<CalculateResponse> Calculate(Operation operation)
        {
            var result = new CalculateResponse
            {
                Result = operation.Calculate()
            };

            return await Task.FromResult(result);
        }
    }
}