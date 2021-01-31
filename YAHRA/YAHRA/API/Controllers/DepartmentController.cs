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
    public class DepartmentController : ApiController
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        // GET api/<controller>
        public List<Department> Get()
        {
            return _departmentService.GetDepartments();
        }
    }
}