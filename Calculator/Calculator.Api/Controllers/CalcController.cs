using System.Threading.Tasks;
using Calculator.Api.Models.Requests;
using Calculator.Api.Models.Responses;
using Calculator.Api.Services;
using Calculator.Api.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Api.Controllers
{
    [Route("api/calc")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly ICalculationService _calculationService;

        public CalcController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpPost]
        public async Task<CalculateResponse> Calculate([FromBody] CalculateRequest request)
        {
            var operation = CalcOperationFactory.GetOperation(request);
            var result = await _calculationService.Calculate(operation);
            return result;
        }
    }
}