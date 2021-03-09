using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Domain.Exceptions
{
    public class ShopsRUsException : Exception
    {
        public ShopsRUsException(string message) : base(message)
        {
        }
    }
}
