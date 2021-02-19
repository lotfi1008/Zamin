using Microsoft.AspNetCore.Mvc;
using Sample.Core.ApplicationServices.Customers.Commands.AddCustomers;
using Sample.Core.ApplicationServices.Customers.Queries.AllCustomers;
using Sample.Core.Domain.Customers.QueryModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zamin.EndPoints.Web.Controllers;

namespace Sample.EndPoints.RestApi.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[Controller]")]
    public class CustomerController : BaseController
    {
        [HttpPost("/Save")]
        public async Task<IActionResult> Post([FromBody] AddCustomerCommand command)
        {
            return await Create<AddCustomerCommand, long>(command);
        }

        [HttpGet("/GetAllCustomer")]
        public async Task <IActionResult> GetAll()
        {
            return await Query<GetAllCustomerQuery, List<CustomerDto>>(new GetAllCustomerQuery());
        }
    }
}
