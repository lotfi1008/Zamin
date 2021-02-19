using Sample.Core.Domain.Customers.QueryModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zamin.Core.Domain.Data;

namespace Sample.Core.Domain.Customers.Repositores
{
    public interface ICustomerQueryRepository : IQueryRepository
    {
        Task<List<CustomerDto>> Select();
    }
}
