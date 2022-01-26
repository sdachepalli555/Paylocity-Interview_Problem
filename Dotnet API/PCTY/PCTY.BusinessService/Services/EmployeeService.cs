using PCTY.BusinessService.Models;
using PCTY.BusinessService.Services.Interfaces;
using PCTY.DataProvider.Models;
using PCTY.DataProvider.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace PCTY.BusinessService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IList<EmployeeModel> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllActiveEmployees();

            if (employees == null)
                return null;

            var employeeVMs = MapEmployeeEntityToModel(employees);

            return employeeVMs;
        }

        public EmployeeModel GetEmployee(int EmployeeID)
        {
            var employee = _employeeRepository.GetEmployee(EmployeeID);

            if (employee == null)
                return null;

            var employeeVM = MapEmployeeEntityToModel(new List<Employee>() { employee });

            return employeeVM.FirstOrDefault();
        }

        public void CalculateBenefitsCost(EmployeeModel employee)
        {
            double benefitCost = Constants.EmployeeBenefitCost;

            if(employee.FirstName.Substring(0, 1).ToLower() == "a")
            {
                benefitCost -= benefitCost * Constants.DiscountOfPersonWithNameStartsA / 100;
            }
            

            foreach(EmployeeDependentModel dependentModel in employee.EmployeeDependents)
            {
                if (dependentModel.FirstName.Substring(0, 1).ToLower() == "a")
                {
                    benefitCost += Constants.DependentBenefitCost - (Constants.DependentBenefitCost * Constants.DiscountOfPersonWithNameStartsA / 100);
                }
                else
                    benefitCost += Constants.DependentBenefitCost;
            }

            employee.BenefitsCostPerYear = benefitCost;

            employee.BenefitsCostPerPayCheck = benefitCost / Constants.NumberofPayPeriods;
        }

        public string SaveEmployee(EmployeeModel employeeVM)
        {
            using (var txscope = new TransactionScope())
            {
                try
                {
                    var employee = MapEmployeeModelToEntity(employeeVM);

                    int employeeID = _employeeRepository.SaveEmployee(employee);

                    if (employeeVM.EmployeeDependents != null)
                    {
                        var dependents = MapEmployeeDependentModelToEntity(employeeID, employeeVM.EmployeeDependents);

                        _employeeRepository.SaveEmployeeDependents(dependents);
                    }

                    txscope.Complete();

                    return "Success";
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
            }                
        }

        private IList<EmployeeModel> MapEmployeeEntityToModel(IList<Employee> employees)
        {
            var employeeVMs = new List<EmployeeModel>();

            foreach(var employee in employees)
            {
                var employeeVM = new EmployeeModel();

                employeeVM.EmployeeId = employee.EmployeeId;
                employeeVM.FirstName = employee.FirstName;
                employeeVM.IsActive = employee.IsActive;
                employeeVM.LastName = employee.LastName;
                employeeVM.Salary = employee.Salary;

                employeeVM.EmployeeDependents = MapEmployeeDependentEntityToModel(employee.EmployeeDependents);

                CalculateBenefitsCost(employeeVM);

                employeeVMs.Add(employeeVM);
            }

            return employeeVMs;
        }

        private IList<EmployeeDependentModel> MapEmployeeDependentEntityToModel(IEnumerable<EmployeeDependent> dependents)
        {
            var dependentVMs = new List<EmployeeDependentModel>();

            foreach(var dependent in dependents)
            {
                var dependentVM = new EmployeeDependentModel();

                dependentVM.DependentId = dependent.DependentId;
                dependentVM.EmployeeId = dependent.EmployeeId;
                dependentVM.FirstName = dependent.FirstName;
                dependentVM.IsActive = dependent.IsActive;
                dependentVM.LastName = dependent.LastName;

                dependentVMs.Add(dependentVM);
            }

            return dependentVMs;
        }

        private Employee MapEmployeeModelToEntity(EmployeeModel employeeVM)
        {
            var employee = new Employee();

            employee.EmployeeId = employeeVM.EmployeeId;
            employee.FirstName = employeeVM.FirstName;
            employee.IsActive = employeeVM.IsActive;
            employee.LastName = employeeVM.LastName;
            employee.Salary = employeeVM.Salary;           

            return employee;
        }

        private IList<EmployeeDependent> MapEmployeeDependentModelToEntity(int employeeId, IList<EmployeeDependentModel> dependentModels)
        {
            var employeeDependents = new List<EmployeeDependent>();

            foreach (var dependentVM in dependentModels)
            {
                var dependent = new EmployeeDependent();

                dependent.DependentId = dependentVM.DependentId;
                dependent.EmployeeId = employeeId;
                dependent.FirstName = dependentVM.FirstName;
                dependent.IsActive = dependentVM.IsActive;
                dependent.LastName = dependentVM.LastName;

                employeeDependents.Add(dependent);
            }

            return employeeDependents;
        }
    }
}
