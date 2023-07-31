using BankApps___Models.Model;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repository.Data
{
    public class Context :  DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
