using System.Threading.Tasks;
using Calculator.Api.Models.Requests;
using Calculator.Api.Models.Responses;
using Calculator.Api.Services.Abstracts;
using PolishNotation;

namespace Calculator.Api.Services
{
    public class CalculationService : ICalculationService
    {
        public async Task<CalculateResponse> Calculate(CalculateRequest request)
        {
            var result = new CalculateResponse
            {
                Result = Expression.Calculate(request.Expression)
            };

            return await Task.FromResult(result);
        }
    }
}