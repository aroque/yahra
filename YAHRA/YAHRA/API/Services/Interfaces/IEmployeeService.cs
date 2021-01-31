using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHRA.Models;
using YAHRA.Models.API;

namespace YAHRA.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees(SortingEnum? sortingOrder, int? pageSize, int? page, string filters);

        Employee GetEmployee(int id);

        Employee UpdateEmployee(int id, Employee employeeNew);
        bool DeleteEmployee(int id);

        Employee CreateEmployee(Employee employeeNew);
    }
}
