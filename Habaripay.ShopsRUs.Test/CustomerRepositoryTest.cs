using Habaripay.ShopsRUs.Api.Controllers.V1;
using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Contracts.Response;
using Habaripay.ShopsRUs.Service.CustomerRepo;
using Habaripay.ShopsRUs.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Habaripay.ShopsRUs.Test
{
    public class CustomerRepositoryTest
    {
        Mock<ICustomerService> mock;
        public CustomerRepositoryTest()
        {
            mock = new Mock<ICustomerService>();
        }

        [Fact]
        public void Test_GetCustomerByEmployee_UsingCustomerId()
        {

            var expected = new CustomerResponse()
            {
                Address = "keru street local road",
                Email = "keru@gamil.com",
                EntryDate = DateTime.Now,
                FirstName = "keru",
                LastName = "local",
                Phone = "08130230146",
                IsEmployee = false,
                IsAffiliate = true,
                Id = 1
            };

            mock.Setup(p => p.GetCustomerById(1)).Returns(Task.Run(() =>
            {
                return ApiResponse<CustomerResponse>.Successful(expected);
            }));

            CustomerController home = new CustomerController(mock.Object);
            Task<IActionResult> result =   home.GetCustomerById(1);

            var objectResult =  result.Result  as OkObjectResult;

            var actual = objectResult.Value as ApiResponse<CustomerResponse>;

            Assert.NotNull(actual.Data);
            Assert.Equal(expected, actual.Data);

        }
    }
}
