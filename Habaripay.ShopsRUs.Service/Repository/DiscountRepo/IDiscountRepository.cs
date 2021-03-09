using Habaripay.ShopsRUs.Data.Entities;
using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Helpers;
using Habaripay.ShopsRUs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Service.Repository.DiscountRepo
{
    public interface IDiscountRepository  : IRepository<Discount>
    {
        Task<ApiResponse<Discount>> GetPercentageByType(string type);
        Task<ApiResponse<Pager<Discount>>> GetDiscounts(SearchModel model);
    }
}
