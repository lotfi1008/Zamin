using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Zamin.Infra.Data.Sql.Queries;

#nullable disable

namespace Sample.Infra.Data.Sql.Query
{
    public class SampleQueryDbContext : BaseQueryDbContext
    {
        public SampleQueryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }


    }

    public class DbContextBuilder : IDesignTimeDbContextFactory<SampleQueryDbContext>
    {
        public SampleQueryDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SampleQueryDbContext>();
            builder.UseSqlServer("Server =DESKTOP-JKSKD96\\MSSQL2019; Database=SampleDb ;User Id =sa;Password=1qaz!QAZ; MultipleActiveResultSets=true");
            return new SampleQueryDbContext(builder.Options);
        }
    }
}
