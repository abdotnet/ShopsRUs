using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
using Habaripay.ShopsRUs.Domain.Models;
using Habaripay.ShopsRUs.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Api.Controllers.V1
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{version:apiVersion}/discounts")]
    [ApiVersion("1")]
    [ApiController]
    public class DiscountController : BaseController
    {

        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] DiscountRequest model)
        {

            var response = await _discountService.CreateDiscount(model);

            return Ok(response);
        }

        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetDiscountByType(string type)
        {

            var response = await _discountService.GetDiscountByType(type);

            return Ok(response);
        }
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [HttpGet]
        public async Task<IActionResult> GetDiscounts([FromQuery] SearchModel model)
        {
            var response = await _discountService.GetDiscounts(model);

            return Ok(response);
        }
    }
}
