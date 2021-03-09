using Habaripay.ShopsRUs.Data.Entities;
using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
using Habaripay.ShopsRUs.Domain.Contracts.Response;
using Habaripay.ShopsRUs.Domain.Helpers;
using Habaripay.ShopsRUs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Service.CustomerRepo
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<ApiResponse<Pager<Customer>>> GetCustomers(SearchModel model);
        Task<ApiResponse<bool>> GetCustomerByAffiliateOfStore(long customerId);
        Task<ApiResponse<bool>> GetCustomerByEmployee(long customerId);
      
        Task<ApiResponse<Customer>> GetCustomerName(string customerName);
    }
}
