using System.ComponentModel.DataAnnotations;
using Zamin.Core.ApplicationServices.Commands;

namespace Sample.Core.ApplicationServices.Customers.Commands.AddCustomers
{
    public class AddCustomerCommand : ICommand<long>
    {
        [Display(Name ="نام")]
        public string FirstName { get; set; }
        [Display(Name ="نام خانوادگی")]
        public string LastName { get; set; }
        [Display(Name ="شماره مشتری")]
        public string CustomerNumber { get; set; }

    }
}
