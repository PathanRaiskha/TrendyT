using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data;
using TrendyT.Services.Interfaces;
using TrendyT.Services.ServiceClasses;
using TrendyT.Services.Helpers;

namespace TrendyT.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterTrendyTServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderServices,OrderService>();
            

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        }
    }
}
