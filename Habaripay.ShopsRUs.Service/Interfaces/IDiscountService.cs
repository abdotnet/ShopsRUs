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
    public interface IDiscountService
    {
        Task<ApiResponse<DiscountResponse>> CreateDiscount(DiscountRequest model);
        Task<ApiResponse<DiscountResponse>> GetDiscountByType(string discountType);
        Task<ApiResponse<Pager<DiscountResponse>>> GetDiscounts(SearchModel model);
    }
}
