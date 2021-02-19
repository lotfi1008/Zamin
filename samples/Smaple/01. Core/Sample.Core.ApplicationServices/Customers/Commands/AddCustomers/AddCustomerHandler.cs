using Sample.Core.Domain.Customers.Entities;
using Sample.Core.Domain.Customers.Repositores;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Utilities;

namespace Sample.Core.ApplicationServices.Customers.Commands.AddCustomers
{
    public class AddCustomerHandler : CommandHandler<AddCustomerCommand, long>
    {
        private readonly ICustomerCommandRepository customerCommandRepository;

        public AddCustomerHandler(ZaminServices zaminServices,ICustomerCommandRepository customerCommandRepository) : base(zaminServices)
        {
            this.customerCommandRepository = customerCommandRepository;
        }

        public override Task<CommandResult<long>> Handle(AddCustomerCommand request)
        {
            var customer = new Customer { 
                CustomerNumber=request.CustomerNumber,
                FirstName=request.FirstName,
                LastName=request.LastName
            };
            customerCommandRepository.Insert(customer);
            customerCommandRepository.Commit();

            return OkAsync(customer.Id);
        }
    }
}
