using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA.Models.Data;

namespace YAHRA.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<employee> GetEmployees();

        employee GetEmployee(int id);

        bool UpdateEmployee(employee employeeNew);
        bool DeleteEmployee(int id);
        bool CreateEmployee(employee employeeNew);
    }
}