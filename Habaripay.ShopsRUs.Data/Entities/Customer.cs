using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Data.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime EntryDate { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsAffiliate { get; set; }
    }
}
