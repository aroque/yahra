using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHRA.Models.API;

namespace YAHRA.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(int id);

        bool UpdateEmployee(Employee employeeNew);
        bool DeleteEmployee(int id);

        bool CreateEmployee(Employee employeeNew);
    }
}
