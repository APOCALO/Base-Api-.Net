using FluentValidation;

namespace Application.Customers.Commands
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(r => r.Name).NotEmpty().MaximumLength(22);
            RuleFor(r => r.LastName).NotEmpty().MaximumLength(22);
            RuleFor(r => r.Country).NotEmpty().MaximumLength(24);
            RuleFor(r => r.Department).NotEmpty().MaximumLength(24);
            RuleFor(r => r.City).NotEmpty().MaximumLength(24);
            RuleFor(r => r.Line).NotEmpty().MaximumLength(10);
        }
    }
}
