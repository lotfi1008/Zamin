using Zamin.Core.Domain.Entities;

namespace Sample.Core.Domain.Customers.Entities
{
    public class Customer : AggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerNumber { get; set; }
    }
}
