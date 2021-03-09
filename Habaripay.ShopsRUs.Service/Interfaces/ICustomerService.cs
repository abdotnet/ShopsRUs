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

namespace Habaripay.ShopsRUs.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<ApiResponse<CustomerResponse>> CreateCustomer(CustomerRequest model);
        Task<ApiResponse<Pager<CustomerResponse>>> GetCustomers(SearchModel model);
        Task<ApiResponse<CustomerResponse>> GetCustomerById(long customerId);
        Task<ApiResponse<CustomerResponse>> GetCustomerByName(string customerName);
    }
}
