using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Data.Entities
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceDate = DateTime.Now;
        }
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountedAmount { get; set; }
        public string ItemPurchasedCategory { get; set; }
    }
}
