using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Domain.Contracts.Request
{
    public class InvoiceRequest
    {
        public long CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string ItemPurchased { get; set; }
    }
}
