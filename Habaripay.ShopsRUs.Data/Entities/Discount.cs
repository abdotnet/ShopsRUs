using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Data.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public bool IsPercentage { get; set; }
        public string Description { get; set; }
        public int Step { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.Now;

    }
}
