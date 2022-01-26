using PCTY.BusinessService.Models;
using System.Collections.Generic;

namespace PCTY.BusinessService.Services.Interfaces
{
    public interface IEmployeeService
    {
        IList<EmployeeModel> GetAllEmployees();

        EmployeeModel GetEmployee(int EmployeeID);

        void CalculateBenefitsCost(EmployeeModel employee);

        string SaveEmployee(EmployeeModel employeeVM);
    }
}
