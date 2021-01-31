using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YAHRA_WebApp.ViewModels
{
    public class EmployeeFormViewModel
    {
        public EmployeeViewModel Employee { get; set; }

        public List<DepartmentViewModel> Departments { get; set; }

        public List<EmployeeStatusViewModel> EmployeeStatuses { get; set; }
    }
}