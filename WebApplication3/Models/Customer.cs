using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication3.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Call = new HashSet<Call>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int CityId { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime? NextCallDate { get; set; }
        public DateTime TsInserted { get; set; }

        public virtual ICollection<Call> Call { get; set; }
    }
}
