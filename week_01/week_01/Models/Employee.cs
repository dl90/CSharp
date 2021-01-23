using System;
using System.Collections.Generic;

#nullable disable

namespace week_01.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Branch { get; set; }

        public virtual Store BranchNavigation { get; set; }
    }
}
