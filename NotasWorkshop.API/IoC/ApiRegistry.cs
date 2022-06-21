using NotasWorkshop.Core.Models;
using NotasWorkshop.Model.Repositories;
using NotasWorkshop.Services.Services;

namespace NotasWorkshop.API.IoC
{
    public static class ApiRegistry
    {
        public static void AddApiRegistry(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBarberProfileRepository,BarberProfileRepository>();
            services.AddScoped<IBarberProfileService,BarberProfileService>();
            services.AddScoped<ITypeHairCutService, TypeHairCutService>();
            services.AddScoped<ITypeHairCutRepository, TypeHairCutRepository>();
            services.AddScoped<IAppointmentService,AppointmentService>();
            services.AddScoped<IReviewService,ReviewService>();
            services.AddScoped<IInvoiceService,InvoiceService>();
        }
        public static void GetConfigurationSections(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }
    }
}
