using Habaripay.ShopsRUs.Service.CustomerRepo;
using Habaripay.ShopsRUs.Service.Repository.DiscountRepo;
using Habaripay.ShopsRUs.Service.Repository.InvoiceRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Service.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customer { get;}
        IDiscountRepository Discount { get; }
        IInvoiceRepository Invoice { get; }

        Task<int> CompleteAsync();
    }
}
