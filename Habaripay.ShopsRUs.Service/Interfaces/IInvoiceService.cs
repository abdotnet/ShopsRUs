using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
using Habaripay.ShopsRUs.Domain.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Service.Interfaces
{
    public interface IInvoiceService
    {
        Task<ApiResponse<InvoiceResponse>> GetTotalInvoiceAmount(InvoiceRequest billAmount);
    }
}
