using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Sample.Core.Domain.Customers.Entities;
using Zamin.Infra.Data.Sql.Commands;

namespace Sample.Infra.Data.Sql.Command.Common
{
    public class SampleCommandDbContext : BaseCommandDbContext
    {
        public SampleCommandDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
        public DbSet<Customer> Customers { get; set; }
    }
    public class DbContextBuilder : IDesignTimeDbContextFactory<SampleCommandDbContext>
    {
        public SampleCommandDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SampleCommandDbContext>();
            builder.UseSqlServer("Server =DESKTOP-JKSKD96\\MSSQL2019; Database=SampleDb ;User Id =sa;Password=1qaz!QAZ; MultipleActiveResultSets=true");
            return new SampleCommandDbContext(builder.Options);
        }
    }
}
