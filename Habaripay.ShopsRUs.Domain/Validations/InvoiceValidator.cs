using FluentValidation;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Domain.Validations
{
    public class InvoiceValidator : AbstractValidator<InvoiceRequest>
    {
        public InvoiceValidator()
        {
            RuleFor(inv => inv.Amount).NotNull().Must(amount => amount > 0);
            RuleFor(inv => inv.CustomerId).NotNull().NotEmpty().Must(customerId => customerId > 0);
            RuleFor(inv => inv.ItemPurchased).NotNull().MinimumLength(3);
        }
    }
}
