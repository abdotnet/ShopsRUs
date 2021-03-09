using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
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
    [Route("api/v{version:apiVersion}/invoices")]
    [ApiVersion("1")]
    [ApiController]
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }


        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] InvoiceRequest model)
        {

            var response = await _invoiceService.GetTotalInvoiceAmount(model);

            return Ok(response);
        }

    }
}
