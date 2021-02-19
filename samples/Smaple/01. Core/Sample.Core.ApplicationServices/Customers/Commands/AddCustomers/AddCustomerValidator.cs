using FluentValidation;
using Sample.Core.Domain.Customers.Entities;

namespace Sample.Core.ApplicationServices.Customers.Commands.AddCustomers
{
    public class AddCustomerValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("{PropertyName} نباید خالی باشد.")
                .NotEqual("").WithMessage("{PropertyName} نباید رشته خالی باشد.");
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("{PropertyName} نباید خالی باشد.")
                .NotEqual("").WithMessage("{PropertyName} نباید رشته خالی باشد.");

        }
    }
    
}
