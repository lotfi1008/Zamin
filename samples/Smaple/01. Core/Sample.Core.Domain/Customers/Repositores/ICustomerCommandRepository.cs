using Sample.Core.Domain.Customers.Entities;
using Zamin.Core.Domain.Data;

namespace Sample.Core.Domain.Customers.Repositores
{
    public interface ICustomerCommandRepository : ICommandRepository<Customer>
    {
    }
}
