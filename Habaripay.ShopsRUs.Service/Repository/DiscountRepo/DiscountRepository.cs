using Habaripay.ShopsRUs.Data;
using Habaripay.ShopsRUs.Data.Entities;
using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Helpers;
using Habaripay.ShopsRUs.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Service.Repository.DiscountRepo
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {

        private readonly ShopsRUsContext _dataContext;
        public DiscountRepository(ShopsRUsContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ApiResponse<Discount>> GetPercentageByType(string type)
        {
            var discount = await _dataContext.Discounts.FirstOrDefaultAsync(c => c.DiscountType == type);

            if (discount == null)
                throw new Exception("Discount not found");

            return ApiResponse<Discount>.Successful(discount);
        }

        public async Task<ApiResponse<Pager<Discount>>> GetDiscounts(SearchModel model)
        {
            var discounts = _dataContext.Discounts.OrderByDescending(ord => ord.EntryDate).AsQueryable();

            PagedList<Discount> pageData = await PagedList<Discount>.CreateAsync(discounts, model.PageNumber, model.PageSize);

            Pager<Discount> pager = new Pager<Discount>()
            {
                CurrentPage = pageData.CurrentPage,
                Result = pageData,
                ItemsPerPage = pageData.PageSize,
                TotalItems = pageData.TotalCount,
                TotalPages = pageData.TotalPages,
            };

            return ApiResponse<Pager<Discount>>.Successful(pager);
        }

    }
}
