using Habaripay.ShopsRUs.Data;
using Habaripay.ShopsRUs.Service.CustomerRepo;
using Habaripay.ShopsRUs.Service.Repository.DiscountRepo;
using Habaripay.ShopsRUs.Service.Repository.InvoiceRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Service.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopsRUsContext _context;
        public ICustomerRepository Customer { get; private set; }
        public IDiscountRepository Discount { get; private set; }
        public IInvoiceRepository Invoice { get; private set; }
        public UnitOfWork(ShopsRUsContext context)
        {
            _context = context;
            Customer = new CustomerRepository(null, _context);
            Discount = new DiscountRepository(_context);
            Invoice = new InvoiceRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
