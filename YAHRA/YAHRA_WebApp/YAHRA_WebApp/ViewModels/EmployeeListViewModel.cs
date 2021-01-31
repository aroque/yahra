using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YAHRA_WebApp.ViewModels
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }

        public List<DepartmentViewModel> Departments { get; set; }

        public List<EmployeeStatusViewModel> EmployeeStatuses { get; set; }
    }
}