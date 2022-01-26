using Microsoft.AspNetCore.Mvc;
using PCTY.BusinessService.Models;
using PCTY.BusinessService.Services.Interfaces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PCTY.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Route("GetEmployees")]
        public IEnumerable<EmployeeModel> GetEmployees()
        {
            return _employeeService.GetAllEmployees();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public EmployeeModel GetEmployee(int id)
        {
            return _employeeService.GetEmployee(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("SaveEmployee")]
        public string SaveEmployee([FromBody] EmployeeModel value)
        {
            return _employeeService.SaveEmployee(value);
        }
    }
}
