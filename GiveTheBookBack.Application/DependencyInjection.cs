using AutoMapper;
using GiveTheBookBack.Application.Interface;
using GiveTheBookBack.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
