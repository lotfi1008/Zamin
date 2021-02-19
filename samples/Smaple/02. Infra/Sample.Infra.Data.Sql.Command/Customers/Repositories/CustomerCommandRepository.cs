using Sample.Core.Domain.Customers.Entities;
using Sample.Core.Domain.Customers.Repositores;
using Sample.Infra.Data.Sql.Command.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace Sample.Infra.Data.Sql.Command.Customers.Repositories
{
    public class CustomerCommandRepository : BaseCommandRepository<Customer, SampleCommandDbContext>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(SampleCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
