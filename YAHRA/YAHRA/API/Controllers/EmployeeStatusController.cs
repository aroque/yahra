using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YAHRA.API.Services.Interfaces;
using YAHRA.Models.API;

namespace YAHRA.API.Controllers
{
    public class EmployeeStatusController : ApiController
    {
        private IEmployeeStatusService _employeeStatusService;

        public EmployeeStatusController(IEmployeeStatusService employeeStatusService)
        {
            _employeeStatusService = employeeStatusService;
        }
        // GET api/<controller>
        public List<EmployeeStatus> Get()
        {
            return _employeeStatusService.GetEmployeeStatuses();
        }
    }
}