using Microsoft.Extensions.DependencyInjection;
using NotasWorkshop.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Services.IoC
{
    public static class ServiceBlob
    {
        public static void AddServicesBlob(this IServiceCollection services)
        {
            services.AddScoped<IFileManagerLogic, FileManagerLogic>();
        }
    }
}
