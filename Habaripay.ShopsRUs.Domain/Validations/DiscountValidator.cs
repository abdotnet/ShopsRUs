using FluentValidation;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Domain.Validations
{
    public class DiscountValidator : AbstractValidator<DiscountRequest>
    {
        public DiscountValidator()
        {
            RuleFor(discount => discount.DiscountType).NotNull().MinimumLength(5);
            RuleFor(discount => discount.DiscountValue).NotNull().Must(discount => discount > 0);
            RuleFor(discount => discount.Description).NotNull().MinimumLength(10);
            RuleFor(discount => discount.Step).NotNull().Must(step => step > 0);
        }
    }
}
