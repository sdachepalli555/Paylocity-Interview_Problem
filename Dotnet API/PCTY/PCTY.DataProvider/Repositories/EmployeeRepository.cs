using Microsoft.EntityFrameworkCore;
using PCTY.DataProvider.Models;
using PCTY.DataProvider.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PCTY.DataProvider.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly PCTYContext _pctyContext;

        public EmployeeRepository(PCTYContext pctyContext)
        {
            _pctyContext = pctyContext;
        }

        public IList<Employee> GetAllActiveEmployees()
        {
            var result = _pctyContext.Employees.Where(x => x.IsActive).Include(x => x.EmployeeDependents).ToList();

            return result;
        }

        public Employee GetEmployee(int employeeID)
        {
            var result = _pctyContext.Employees.Find(employeeID);

            return result;
        }

        public int SaveEmployee(Employee employee)
        {
            var result = _pctyContext.Employees.Add(employee);
            _pctyContext.SaveChanges();

            return employee.EmployeeId;
        }

        public void SaveEmployeeDependents(IList<EmployeeDependent> employeeDependents)
        {
            _pctyContext.EmployeeDependents.AddRange(employeeDependents);

            _pctyContext.SaveChanges();
        }
    }
}
