using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Domain.Contracts.Request
{
    public class CustomerRequest
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsAffiliate { get; set; }
    }
}
