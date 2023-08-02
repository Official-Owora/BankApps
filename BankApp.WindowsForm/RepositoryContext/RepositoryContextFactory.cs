using BankApp.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BankApp.WindowsForm.RepositoryContext
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<Context>()
                .UseSqlServer(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly("BankApp.Repository"));
            return new Context(builder.Options);
        }
    }
}
