using Calculator.Api.Models.Requests;
using FluentValidation;

namespace Calculator.Api.Validators
{
    public class CalculateRequestValidator : AbstractValidator<CalculateRequest>
    {
        public CalculateRequestValidator()
        {
            RuleFor(x => x.Expression)
                .NotNull();
        }
    }
}