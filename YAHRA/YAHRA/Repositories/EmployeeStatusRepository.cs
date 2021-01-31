using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA.Models.Data;
using YAHRA.Repositories.Interfaces;

namespace YAHRA.Repositories
{
    public class EmployeeStatusRepository : IEmployeeStatusRepository
    {
        public List<employee_status> GetEmployeeStatuses()
        {
            using (var context = new YAHRA_DBEntities())
            {
                return context.employee_status.ToList<employee_status>();
            }
        }
    }
}