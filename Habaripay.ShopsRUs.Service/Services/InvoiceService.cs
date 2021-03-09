using AutoMapper;
using Habaripay.ShopsRUs.Data.Entities;
using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
using Habaripay.ShopsRUs.Domain.Contracts.Response;
using Habaripay.ShopsRUs.Service.Interfaces;
using Habaripay.ShopsRUs.Service.Uow;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Service
{
    public class InvoiceService : IInvoiceService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<InvoiceService> _logger;
        public InvoiceService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<InvoiceService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="billAmount"></param>
        /// <returns></returns>
        public async Task<ApiResponse<InvoiceResponse>> GetTotalInvoiceAmount(InvoiceRequest request)
        {
            _logger.LogInformation("Request: {@request}", request);

            if (request == null)
                throw new Exception("Invoice items cannot be empty");


            var discounts = await _unitOfWork.Discount.GetAll();
            // loop over all the discount and apply only 1 type of discount to a user 

            bool isItemCategoryGroceries = false;
            decimal discountedAmount = 0;

            // For every $100 on the bill, there would be a $5 discount(e.g. for $990, you get
            //$45 as a discount)
            // The percentage based discounts do not apply on groceries
            // A user can get only one of the percentage based discounts on a bill

            foreach (var discount in discounts.OrderBy(c => c.Step))
            {

                isItemCategoryGroceries = request.ItemPurchased.Contains("groceries");

                // All discount conditions not met
                if (isItemCategoryGroceries && request.Amount < 100)
                    break;

                // If the user is an affiliate of the store, user gets a 10 % discount
                //sample customer Id : 1002
                if (!isItemCategoryGroceries && discount.Step == 1)
                {
                    discountedAmount = await GetAffiliateCustomer(request, discount);
                }
                // customer id : 1001
                else if (!isItemCategoryGroceries && discount.Step == 2)  // If the user is an employee of the store, user gets a 30 % discount
                {
                    discountedAmount = await GetEmployeeCustomer(request, discount);
                }
                // customer id  : 1003
                else if (!isItemCategoryGroceries && discount.Step == 3) //If the user has been a customer for over 2 years, user gets a 5 % discount
                {
                    discountedAmount = await GetTwoYearsLoyalCustomer(request, discount);
                }
                // For every $100 on the bill, there would be a $5 discount(e.g. for $990, you get
                //$45 as a discount)
                else if (request.Amount >= 100 && discount.Step == 4)
                {
                    int billMode = (int)Math.Floor(request.Amount / 100);

                    discountedAmount = billMode * discount.DiscountValue;
                }
                if (discountedAmount > 0) break;
            }

            string invoiceNo = "INV-" + Guid.NewGuid().ToString().Substring(0, 8).Replace("-", "").ToUpper();

            _unitOfWork.Invoice.Add(new Data.Entities.Invoice()
            {
                CustomerId = request.CustomerId,
                DiscountedAmount = discountedAmount,
                InvoiceDate = DateTime.Now,
                ItemPurchasedCategory = request.ItemPurchased,
                InvoiceNo = invoiceNo,
                TotalAmount = request.Amount
            });
            await _unitOfWork.CompleteAsync();

            InvoiceResponse invResponse = new InvoiceResponse()
            {
                TotalAmount = request.Amount,
                CustomerId = request.CustomerId,
                DiscountedAmount = discountedAmount,
                InvoiceDate = DateTime.Now,
                InvoiceNo = invoiceNo,
                ItemPurchasedCategory = request.ItemPurchased,
                TotalPayeableAmount = request.Amount - discountedAmount
            };

            _logger.LogInformation("Response: {@invResponse}", invResponse);

            return ApiResponse<InvoiceResponse>.Successful(invResponse);
        }

     
        private async Task<decimal> GetAffiliateCustomer(InvoiceRequest request, Discount discount)
        {
            decimal discountedAmount = 0;

            var affiliateCustomer = await _unitOfWork.Customer.GetCustomerByAffiliateOfStore(request.CustomerId);

            if (affiliateCustomer.Data)
            {
                discountedAmount = (request.Amount * discount.DiscountValue) / 100;
            }
            return discountedAmount;
        }

        private async Task<decimal> GetEmployeeCustomer(InvoiceRequest request, Discount discount)
        {
            decimal discountedAmount = 0;
            var employeeCustomer = await _unitOfWork.Customer.GetCustomerByEmployee(request.CustomerId);

            if (employeeCustomer.Data)
            {
                discountedAmount = (request.Amount * discount.DiscountValue) / 100;
            }

            return discountedAmount;
        }

        private async Task<decimal> GetTwoYearsLoyalCustomer(InvoiceRequest request, Discount discount)
        {
            decimal discountedAmount = 0;
            var twoYearsLoyalty = await _unitOfWork.Invoice.GetCustomerByOverTwoLoyality(request.CustomerId);

            if (twoYearsLoyalty.Data)
            {
                discountedAmount = (request.Amount * discount.DiscountValue) / 100;
            }

            return discountedAmount;
        }



    }
}