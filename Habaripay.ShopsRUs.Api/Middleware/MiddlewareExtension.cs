using FluentValidation.AspNetCore;
using Habaripay.ShopsRUs.Domain.Validations;
using Habaripay.ShopsRUs.Service;
using Habaripay.ShopsRUs.Service.CustomerRepo;
using Habaripay.ShopsRUs.Service.Interfaces;
using Habaripay.ShopsRUs.Service.Repository.DiscountRepo;
using Habaripay.ShopsRUs.Service.Repository.InvoiceRepo;
using Habaripay.ShopsRUs.Service.Services;
using Habaripay.ShopsRUs.Service.Uow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Api.Middleware
{
    public static class MiddlewareExtension
    {
        #region Filter handler 

        public static void AddFilterConfiguration(this IServiceCollection services)
        {
            services.AddMvc(config => config.Filters.Add<ValidationFilters>())
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                })
              .AddFluentValidation(opt =>
              {
                  opt.RegisterValidatorsFromAssemblyContaining<CustomerValidator>();
              });


            //register abstract validator classes
            // services.AddTransient<IValidator<GatewayPayoutRequest>, GatewayPayoutRequestValidator>();
        }
        #endregion


        #region CORS Configuration
        /// <summary>
        /// Injects core dependencies.
        /// </summary>
        /// <param name="services">The service collection descriptor</param>
        /// <param name="Configuration">The configuration properties</param>
        public static void AddCorsMiddleWare(this IServiceCollection services, IConfiguration Configuration)
        {
            string[] urls = Configuration.GetSection("Cors").Get<string[]>();
            services.AddCors(Options =>
            {
                Options.AddPolicy(name: "ShopsRUPolicy",
                    builder =>
                    builder.WithOrigins(String.Join(",", urls))
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowCredentials()
                    );
            });
        }
        #endregion

        public static void AddServicesConfiguration(this IServiceCollection services)
        {

            // services
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<IDiscountService, DiscountService>();

            // Repositories

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();

        }


    }
}
