using Habaripay.ShopsRUs.Data;
using Habaripay.ShopsRUs.Data.Entities;
using Habaripay.ShopsRUs.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Service.Repository.InvoiceRepo
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly ShopsRUsContext _dataContext;

        public InvoiceRepository(ShopsRUsContext dataContext) : base(dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<ApiResponse<bool>> GetCustomerByOverTwoLoyality(long customerId)
        {
            DateTime twoYearsAgo = DateTime.Now.AddYears(-2);
            // c.Id == customerId

            var customer = await _dataContext.Invoices.AnyAsync(c =>c.CustomerId == customerId && c.InvoiceDate.Year >= twoYearsAgo.Year);

            return ApiResponse<bool>.Successful(customer);
        }

    }
}
