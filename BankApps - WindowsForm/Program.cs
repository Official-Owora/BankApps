using BankApp.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace BankApps___WindowsForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static IConfiguration Configuration;
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}