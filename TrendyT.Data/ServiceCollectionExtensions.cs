using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;
using TrendyT.Data.Repository.RepoInterfaces;
using TrendyT.Data.Repository.Repos;

namespace TrendyT.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterTrendyTDataLayer(this IServiceCollection services, string connectionString)
        {
            //var builder = services.AddIdentityCore<ApplicationUser>(x => x.User.RequireUniqueEmail = true);
            //builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            //builder.AddEntityFrameworkStores<ApplicationDbContext>(); 
                //.AddTokenProvider(TokenOptions.DefaultProvider, typeof(DataProtectorTokenProvider<ApplicationUser>));

            services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork,UnitOfWork>();

            
        }
    }
}
