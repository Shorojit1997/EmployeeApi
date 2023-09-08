using EmployeeApi.Repository;
using EmployeeApi.Services;
using System.Runtime.CompilerServices;

namespace EmployeeApi.Extensions
{
    public static class PowerHouse
    {

        public static IServiceCollection RegisterDependency(this IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
            services.AddScoped<UnitOfService>();
        
            return services;
        }
    }
}
