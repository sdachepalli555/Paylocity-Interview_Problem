using System.Collections.Generic;

namespace PCTY.BusinessService.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
        public double BenefitsCostPerYear { get; set; }
        public double BenefitsCostPerPayCheck { get; set; }
        public string DisplpayName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public string DependentNames
        {
            get
            {
                if(EmployeeDependents != null)
                {
                    List<string> names = new List<string>();
                    foreach(var dependent in EmployeeDependents)
                    {
                        names.Add(dependent.LastName + ", " + dependent.FirstName);
                    }

                    return string.Join(" ; ", names);
                }

                return string.Empty;
            }
        }

        public int DependentCount
        {
            get
            {
                if (EmployeeDependents != null)
                {
                    return EmployeeDependents.Count;
                }

                return 0;
            }
        }

        public  IList<EmployeeDependentModel> EmployeeDependents { get; set; }
    }
}
