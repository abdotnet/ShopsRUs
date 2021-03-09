using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Domain.Contracts.Request
{
    public class DiscountRequest
    {
        public string DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public string Description { get; set; }
        public bool IsPercentage { get; set; }
        public int Step { get; set; }
    }
}
