using Habaripay.ShopsRUs.Data.Entities;
using Habaripay.ShopsRUs.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Service.Repository.InvoiceRepo
{
    public interface IInvoiceRepository :IRepository<Invoice>
    {
        Task<ApiResponse<bool>> GetCustomerByOverTwoLoyality(long customerId);

    }
}
