using AutoMapper;
using Habaripay.ShopsRUs.Data.Entities;
using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
using Habaripay.ShopsRUs.Domain.Contracts.Response;
using Habaripay.ShopsRUs.Domain.Helpers;
using Habaripay.ShopsRUs.Domain.Models;
using Habaripay.ShopsRUs.Service.Interfaces;
using Habaripay.ShopsRUs.Service.Uow;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<CustomerService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        public async Task<ApiResponse<CustomerResponse>> CreateCustomer(CustomerRequest model)
        {
            if (model == null)
                throw new Exception("Customer request model cannot be empty");

            var customer = _mapper.Map<Customer>(model);

            _unitOfWork.Customer.Add(customer);
            await _unitOfWork.CompleteAsync();

            return ApiResponse<CustomerResponse>.Successful(null);

        }

        public async Task<ApiResponse<Pager<CustomerResponse>>> GetCustomers(SearchModel model)
        {
            var customerUow = await _unitOfWork.Customer.GetCustomers(model);

            var customers = _mapper.Map<Pager<CustomerResponse>>(customerUow.Data);

            return ApiResponse<Pager<CustomerResponse>>.Successful(customers, customerUow.Status, customerUow.Message);
        }

        public async Task<ApiResponse<CustomerResponse>> GetCustomerById(long customerId)
        {
            var customerUow = await _unitOfWork.Customer.Get(customerId);

            var customer = _mapper.Map<CustomerResponse>(customerUow);

            return ApiResponse<CustomerResponse>.Successful(customer);
        }
        public async Task<ApiResponse<CustomerResponse>> GetCustomerByName(string customerName)
        {

            var customerUow = await _unitOfWork.Customer.GetCustomerName(customerName);

            var customer = _mapper.Map<CustomerResponse>(customerUow.Data);

            return ApiResponse<CustomerResponse>.Successful(customer);
        }

    }
}
