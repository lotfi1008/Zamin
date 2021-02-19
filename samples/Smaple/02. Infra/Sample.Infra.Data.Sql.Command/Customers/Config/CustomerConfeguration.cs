using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Core.Domain.Customers.Entities;
using System;

namespace Sample.Infra.Data.Sql.Command.Customers.Config
{
    public class CustomerConfeguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
           
        }
    }
}
