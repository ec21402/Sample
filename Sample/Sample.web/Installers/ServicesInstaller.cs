using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.web.Installers
{
    public static class ServicesInstaller
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<IBrandService, BrandService>();
        }
    }
}
