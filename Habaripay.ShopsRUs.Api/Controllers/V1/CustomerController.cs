using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
using Habaripay.ShopsRUs.Domain.Models;
using Habaripay.ShopsRUs.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Api.Controllers.V1
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{version:apiVersion}/customers")]
    [ApiVersion("1")]
    [ApiController]
    public class CustomerController : BaseController
    {

        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {

            _customerService = customerService;
        }
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequest model)
        {
            Log.Information("Request {@model}", model);

            var response = await _customerService.CreateCustomer(model);

            Log.Information("Request {@model}", response);
            return Ok(response);
        }

        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery] SearchModel model)
        {

            var response = await _customerService.GetCustomers(model);
            return Ok(response);
        }

        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [HttpGet("id/{customerId}")]
        public async Task<IActionResult> GetCustomerById([Required] long customerId)
        {
            var response = await _customerService.GetCustomerById(customerId);

            return Ok(response);
        }
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [HttpGet("name/{customerName}")]
        public async Task<IActionResult> GetCustomerByName([Required] string customerName)
        {

            var response = await _customerService.GetCustomerByName(customerName);

            return Ok(response);
        }

    }
}
