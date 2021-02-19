using System;
using System.Collections.Generic;

#nullable disable

namespace Sample.Infra.Data.Sql.Query
{
    public partial class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerNumber { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? ModifiedByUserId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public Guid BusinessId { get; set; }
    }
}
