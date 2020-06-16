using System.Threading.Tasks;
using Calculator.Api.Models.Requests;
using Calculator.Api.Models.Responses;

namespace Calculator.Api.Services.Abstracts
{
    public interface ICalculationService
    {
        Task<CalculateResponse> Calculate(CalculateRequest request);
    }
}