using AutoMapper;
using Habaripay.ShopsRUs.Data;
using Habaripay.ShopsRUs.Data.Entities;
using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
using Habaripay.ShopsRUs.Domain.Contracts.Response;
using Habaripay.ShopsRUs.Domain.Helpers;
using Habaripay.ShopsRUs.Domain.Models;
using Habaripay.ShopsRUs.Service.Uow;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Service.CustomerRepo
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ShopsRUsContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(IMapper mapper, ShopsRUsContext context) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Customer>> GetCustomerName(string customerName)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.LastName == customerName || c.FirstName == customerName);

            if (customer == null)
                throw new Exception("Customer not found");

            return ApiResponse<Customer>.Successful(customer);
        }

        public async Task<ApiResponse<bool>> GetCustomerByEmployee(long customerId)
        {
            var customer = await _context.Customers.AnyAsync(c => c.Id == customerId && !c.IsAffiliate && c.IsEmployee);


            return ApiResponse<bool>.Successful(customer);
        }

       

        public async Task<ApiResponse<bool>> GetCustomerByAffiliateOfStore(long customerId)
        {
            var customer = await _context.Customers.AnyAsync(c => c.Id == customerId && c.IsAffiliate && !c.IsEmployee);

            return ApiResponse<bool>.Successful(customer);
        }

        public async Task<ApiResponse<Pager<Customer>>> GetCustomers(SearchModel model)
        {
            var customer = _context.Customers.OrderByDescending(ord => ord.EntryDate).AsQueryable();


            PagedList<Customer> pageData = await PagedList<Customer>.CreateAsync(customer, model.PageNumber, model.PageSize);

            Pager<Customer> pager = new Pager<Customer>()
            {
                CurrentPage = pageData.CurrentPage,
                Result = pageData,
                ItemsPerPage = pageData.PageSize,
                TotalItems = pageData.TotalCount,
                TotalPages = pageData.TotalPages,
            };

            return ApiResponse<Pager<Customer>>.Successful(pager);
        }

    }
}
