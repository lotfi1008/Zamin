using Microsoft.EntityFrameworkCore;
using Sample.Core.Domain.Customers.QueryModels;
using Sample.Core.Domain.Customers.Repositores;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zamin.Infra.Data.Sql.Queries;

namespace Sample.Infra.Data.Sql.Query.Customers.Repositories
{
    public class CustomerQueryRepository : BaseQueryRepository<SampleQueryDbContext>,ICustomerQueryRepository
    {
        public CustomerQueryRepository(SampleQueryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<CustomerDto>> Select()
        {
            var res= await _dbContext.Customers.AsNoTracking()
                .Select(c => new CustomerDto()
                {
                    BusinessId = c.BusinessId,
                    CreatedByUserId = c.CreatedByUserId,
                    CreatedDateTime = c.CreatedDateTime,
                    CustomerNumber = c.CustomerNumber,
                    FirstName = c.FirstName,
                    Id = c.Id,
                    LastName = c.LastName,
                    ModifiedByUserId = c.ModifiedByUserId,
                    ModifiedDateTime = c.ModifiedDateTime
                }).ToListAsync();
            return res;
        }
    }
}
