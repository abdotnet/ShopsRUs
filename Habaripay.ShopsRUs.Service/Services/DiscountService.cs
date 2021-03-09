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
    public class DiscountService : IDiscountService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DiscountService> _logger;
        public DiscountService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<DiscountService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<DiscountResponse>> CreateDiscount(DiscountRequest model)
        {
            if (model == null)
                throw new Exception("Discount cannot be empty");

            var discount = _mapper.Map<Discount>(model);

            _unitOfWork.Discount.Add(discount);
            await _unitOfWork.CompleteAsync();

            var discountResponse = _mapper.Map<DiscountResponse>(discount);

            return ApiResponse<DiscountResponse>.Successful(discountResponse);
        }

        public async Task<ApiResponse<DiscountResponse>> GetDiscountByType(string discountType)
        {

            var discount = await _unitOfWork.Discount.GetPercentageByType(discountType);

            var discountResponse = _mapper.Map<DiscountResponse>(discount.Data);

            return ApiResponse<DiscountResponse>.Successful(discountResponse);
        }

        public async Task<ApiResponse<Pager<DiscountResponse>>> GetDiscounts(SearchModel model)
        {
            var discountUow = await _unitOfWork.Discount.GetDiscounts(model);

            var discounts = _mapper.Map<Pager<DiscountResponse>>(discountUow.Data);

            return ApiResponse<Pager<DiscountResponse>>.Successful(discounts, discountUow.Status, discountUow.Message);

        }

    }
}
