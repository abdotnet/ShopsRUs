using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Domain.Contracts.Response
{
    public class DiscountResponse
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
