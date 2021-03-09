using Habaripay.ShopsRUs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Api.Middleware
{
    public static class DataMiddleWareExtension
    {
        public static void AddDbContext(this IServiceCollection service, IConfiguration Configuration)
        {
            service.AddDbContextPool<ShopsRUsContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Habaripay.ShopsRUs.Data")));

        }
    }
}
