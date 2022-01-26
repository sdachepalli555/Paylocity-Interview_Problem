namespace PCTY.BusinessService.Models
{
    public class EmployeeDependentModel
    {
        public int DependentId { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public EmployeeModel Employee { get; set; }
    }
}
