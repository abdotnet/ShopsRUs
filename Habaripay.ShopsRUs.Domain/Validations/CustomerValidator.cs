using FluentValidation;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Domain.Validations
{
    public class CustomerValidator : AbstractValidator<CustomerRequest>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotNull().MinimumLength(3);
            RuleFor(customer => customer.LastName).NotNull().MinimumLength(3);
            RuleFor(customer => customer.Phone).NotNull().MinimumLength(7);
            RuleFor(customer => customer.IsEmployee).NotNull().NotEmpty();
            RuleFor(customer => customer.IsAffiliate).NotNull().NotEmpty();
            RuleFor(customer => customer.Email).NotEmpty().WithMessage("Email address is required ")
                .EmailAddress().WithMessage("The email must be a valid email address");
        }
    }
}
