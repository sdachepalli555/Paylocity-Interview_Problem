#nullable disable

namespace PCTY.DataProvider.Models
{
    public partial class EmployeeDependent
    {
        public int DependentId { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
