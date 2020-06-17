using System.Threading.Tasks;
using Calculator.Api.Models.Operations;
using Calculator.Api.Models.Responses;

namespace Calculator.Api.Services.Abstracts
{
    public interface ICalculationService
    {
        Task<CalculateResponse> Calculate(Operation operation);
    }
}