using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using YAHRA.API.Services.Interfaces;
using YAHRA.Models;
using YAHRA.Models.API;

namespace YAHRA.API
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET api/<controller>
        public List<Employee> Get(SortingEnum? sortingOrder = null, int? pageSize = null, int? page = null, string filters = null)
        {
            return _employeeService.GetEmployees(sortingOrder, pageSize, page, filters);
        }

        // GET api/<controller>/5
        public Employee Get(int id)
        {
            return _employeeService.GetEmployee(id);
        }

        // POST api/<controller>
        public Employee Post([FromBody] Employee employee)
        {
            return _employeeService.CreateEmployee(employee);
        }

        // PUT api/<controller>/5
        public Employee Put(int id, [FromBody] Employee employee)
        {
            return _employeeService.UpdateEmployee(id, employee);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return _employeeService.DeleteEmployee(id);
        }
    }
}