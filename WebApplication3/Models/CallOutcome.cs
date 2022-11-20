using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication3.Models
{
    public partial class CallOutcome
    {
        public CallOutcome()
        {
            Call = new HashSet<Call>();
        }

        public int Id { get; set; }
        public string OutcomeText { get; set; }

        public virtual ICollection<Call> Call { get; set; }
    }
}
