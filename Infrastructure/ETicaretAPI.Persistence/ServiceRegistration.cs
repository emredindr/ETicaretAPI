using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services) 
        {
            services.AddDbContext<ETicaretAPIDbContext>(option =>option.UseNpgsql("User ID=postgres;Password=emre77;Host=localhost;Port=5432;Database=ETicaretAPIDb;"));
           

        } 
    }
}
