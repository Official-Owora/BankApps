using BankApp.Repository.Data;
using BankApp.WindowsForm.ServiceExtension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System;

namespace BankApp.WindowsForm
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
            ApplicationConfiguration.Initialize();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            ServiceCollection services = new ServiceCollection();
            //Add services here
           // services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddDbContext<Context>(options => options.UseSqlServer("Data Source=EMEKA-IACADEMY\\SQLEXPRESS;Initial Catalog=BankApp_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
            services.ConfigureUnitOfWork();
            services.ConfigureServiceManager();
            services.AddTransient<Form1>();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            var form1 = serviceProvider.GetRequiredService<Form1>();
            Application.Run(form1);
        }
    }
}