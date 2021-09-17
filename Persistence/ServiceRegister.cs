using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contracts;
using Persistence.Repository;

namespace Persistence
{
    public static class ServiceRegister
    {
        public static void AddDbRepository(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<HotelDBContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("SourceDbContext"));
            });
            services.AddScoped<DbContext, HotelDBContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
