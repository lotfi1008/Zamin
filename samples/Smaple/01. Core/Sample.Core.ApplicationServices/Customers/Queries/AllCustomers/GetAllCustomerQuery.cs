using Sample.Core.Domain.Customers.QueryModels;
using Sample.Core.Domain.Customers.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Utilities;

namespace Sample.Core.ApplicationServices.Customers.Queries.AllCustomers
{
    public class GetAllCustomerQuery:IQuery<List<CustomerDto>>
    {
    }

    public class GetAllCustomerQueryHandler : QueryHandler<GetAllCustomerQuery, List<CustomerDto>>
    {
        private readonly ICustomerQueryRepository customerQueryRepository;

        public GetAllCustomerQueryHandler(ZaminServices zaminApplicationContext,ICustomerQueryRepository customerQueryRepository) : base(zaminApplicationContext)
        {
            this.customerQueryRepository = customerQueryRepository;
        }

        public async override Task<QueryResult<List<CustomerDto>>> Handle(GetAllCustomerQuery request)
        {
            var res = await customerQueryRepository.Select();

            return Result(res);
        }
    }


}
