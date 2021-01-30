using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YAHRA.API.Services.Interfaces;
using YAHRA.Models.API;

namespace YAHRA.API
{
    public class EmployeeApiController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeApiController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET api/<controller>
        public List<Employee> Get()
        {
            return _employeeService.GetEmployees();
        }

        // GET api/<controller>/5
        public Employee Get(int id) => _employeeService.GetEmployee(id);

        // POST api/<controller>
        public void Post([FromBody] Employee employee)
        {
            _employeeService.CreateEmployee(employee);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Employee employee)
        {
            return _employeeService.UpdateEmployee(employee);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return _employeeService.DeleteEmployee(id);
        }
    }
}