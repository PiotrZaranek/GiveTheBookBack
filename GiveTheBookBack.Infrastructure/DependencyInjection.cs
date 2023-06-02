using GiveTheBookBack.Domain.Interface;
using GiveTheBookBack.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();           
            services.AddTransient<IUserRepository, UserRepository>();           
        }
    }
}
