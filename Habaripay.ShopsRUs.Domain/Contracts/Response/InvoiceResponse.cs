using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Domain.Contracts.Response
{
    public class InvoiceResponse
    {
        public InvoiceResponse()
        {
            InvoiceDate = DateTime.Now.Date;
        }
        public long CustomerId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountedAmount { get; set; }
        public decimal TotalPayeableAmount { get; set; }
        public string ItemPurchasedCategory { get; set; }

    }
}
