using PCTY.DataProvider.Models;
using System.Collections.Generic;

namespace PCTY.DataProvider.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int EmployeeID);

        IList<Employee> GetAllActiveEmployees();

        int SaveEmployee(Employee employee);

        void SaveEmployeeDependents(IList<EmployeeDependent> employeeDependents);
    }
}
