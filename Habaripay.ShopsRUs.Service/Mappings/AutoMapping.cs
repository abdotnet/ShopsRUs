using AutoMapper;
using Habaripay.ShopsRUs.Data.Entities;
using Habaripay.ShopsRUs.Domain.Contracts.Request;
using Habaripay.ShopsRUs.Domain.Contracts.Response;
using Habaripay.ShopsRUs.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Service.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Customer, CustomerRequest>().ReverseMap(); // means you want to map from Customer to UserDTO
            CreateMap<Pager<CustomerResponse>, Pager<Customer>>().ReverseMap();
            CreateMap<CustomerResponse, Customer>().ReverseMap();
            CreateMap<Pager<CustomerResponse>, Pager<Customer>>().ReverseMap();

            CreateMap<Pager<DiscountResponse>, Pager<Discount>>().ReverseMap();
            CreateMap<DiscountResponse, Discount>().ReverseMap();
            CreateMap<DiscountRequest, Discount>().ReverseMap();
        }
    }
}
