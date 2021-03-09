using Habaripay.ShopsRUs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Data
{
    public class Seed
    {

        public static void SeedData(ShopsRUsContext context)
        {
            if (!context.Customers.Any())
            {
                Customer customer = null;
                Enumerable.Range(1, 1000).ToList().ForEach((x) =>
                {
                    var firstName = Faker.Name.FirstName();
                    var lastName = Faker.Name.LastName();
                    customer = new Customer();
                    customer.LastName = firstName;
                    customer.FirstName = lastName;
                    customer.Address = Faker.Address.StreetName();
                    customer.Email = Faker.User.Email();
                    int days = -((int)new Random().Next(0, 800));
                    customer.EntryDate = DateTime.Now.AddDays(days);
                    var isRandEmployee = new Random().Next(1, 3);

                    customer.IsEmployee = (isRandEmployee % 2 == 0) ? true : false;
                    var isRandAffiliate = new Random().Next(3, 5);
                    customer.IsAffiliate = isRandAffiliate % 2 == 0 ? true : false;
                    customer.Phone = Faker.Phone.GetPhoneNumber();
                    context.Customers.Add(customer);
                });
                // 1001 - for condition1
                var firstName = Faker.Name.FirstName();
                var lastName = Faker.Name.LastName();
                customer = new Customer();
                customer.LastName = firstName;
                customer.FirstName = lastName;
                customer.Address = Faker.Address.StreetName();
                customer.Email = Faker.User.Email();
                int days = -((int)new Random().Next(0, 800));
                customer.EntryDate = DateTime.Now.AddDays(days);
                var isRandEmployee = new Random().Next(1, 3);

                customer.IsEmployee = false;
                var isRandAffiliate = new Random().Next(3, 5);
                customer.IsAffiliate = true;
                customer.Phone = Faker.Phone.GetPhoneNumber();
                context.Customers.Add(customer);


                // 1002 - for condition2
                firstName = Faker.Name.FirstName();
                lastName = Faker.Name.LastName();
                customer = new Customer();
                customer.LastName = firstName;
                customer.FirstName = lastName;
                customer.Address = Faker.Address.StreetName();
                customer.Email = Faker.User.Email();
                days = -((int)new Random().Next(0, 800));
                customer.EntryDate = DateTime.Now.AddDays(days);
                isRandEmployee = new Random().Next(1, 3);

                customer.IsEmployee = true;
                isRandAffiliate = new Random().Next(3, 5);
                customer.IsAffiliate = false;
                customer.Phone = Faker.Phone.GetPhoneNumber();
                context.Customers.Add(customer);

                // 1003 - for condition3
                firstName = Faker.Name.FirstName();
                lastName = Faker.Name.LastName();
                customer = new Customer();
                customer.LastName = firstName;
                customer.FirstName = lastName;
                customer.Address = Faker.Address.StreetName();
                customer.Email = Faker.User.Email();
                days = -((int)new Random().Next(0, 800));
                customer.EntryDate = DateTime.Now.AddDays(days);
                isRandEmployee = new Random().Next(1, 3);

                customer.IsEmployee = false;
                isRandAffiliate = new Random().Next(3, 5);
                customer.IsAffiliate = false;
                customer.Phone = Faker.Phone.GetPhoneNumber();
                context.Customers.Add(customer);
                context.SaveChanges();
            }

            if (!context.Invoices.Any())
            {

                Invoice invoice = null;

                Enumerable.Range(1, 800).ToList().ForEach((x) =>
                {
                    invoice = new Invoice();
                    invoice.TotalAmount = new Random().Next(100, 1000);
                    invoice.DiscountedAmount = invoice.TotalAmount - new Random().Next(10, 95);
                    invoice.CustomerId = 1003;

                    invoice.InvoiceDate = DateTime.Now.AddDays(-x);
                    invoice.InvoiceNo = $"INV10{x}";
                    invoice.ItemPurchasedCategory = Faker.Commerce.Product();
                    context.Invoices.Add(invoice);
                });
                context.SaveChanges();
            }

            if (!context.Discounts.Any())
            {
                Discount discount = new Discount()
                {
                    EntryDate = DateTime.Now,
                    DiscountType = "Affiliate",
                    DiscountValue = 10,
                    IsPercentage = true,
                    Description = "",
                    Step = 1

                };
                context.Discounts.Add(discount);

                discount = new Discount()
                {
                    EntryDate = DateTime.Now,
                    DiscountType = "Employee",
                    DiscountValue = 30,
                    IsPercentage = true,
                    Description = "",
                    Step = 2
                };
                context.Discounts.Add(discount);

                discount = new Discount()
                {
                    EntryDate = DateTime.Now,
                    DiscountType = "Two_Years_Customer",
                    DiscountValue = 5,
                    IsPercentage = true,
                    Description = "",
                    Step = 3

                };
                context.Discounts.Add(discount);

                Discount _discount = new Discount()
                {
                    EntryDate = DateTime.Now,
                    DiscountType = "100_dollar_bill",
                    DiscountValue = 5,
                    IsPercentage = false,
                    Description = "",
                    Step = 4

                };
                context.Discounts.Add(_discount);

                context.SaveChanges();
            }



        }
    }
}
