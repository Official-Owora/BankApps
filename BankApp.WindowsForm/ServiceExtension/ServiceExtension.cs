using BankApp.Core.ServiceManager.Abstraction;
using BankApp.Core.ServiceManager.Implementation;
using BankApp.Repository.UnitOfWork.Abstraction;
using BankApp.Repository.UnitOfWork.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.WindowsForm.ServiceExtension
{
    public static class ServiceExtension
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
    }
}
