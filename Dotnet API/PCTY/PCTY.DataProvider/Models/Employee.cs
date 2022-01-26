using System.Collections.Generic;

#nullable disable

namespace PCTY.DataProvider.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeDependents = new HashSet<EmployeeDependent>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EmployeeDependent> EmployeeDependents { get; set; }
    }
}
