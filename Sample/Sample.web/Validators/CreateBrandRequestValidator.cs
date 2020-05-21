using FluentValidation;
using Sample.web.Contracts.V1.Request;

namespace Sample.web.Validators
{
    public class CreateBrandRequestValidator : AbstractValidator<CreateBrandRequest>
    {
        public CreateBrandRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("只能輸入0-9及A-Z");
        }
    }
}
