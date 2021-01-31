using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA.Models;
using YAHRA.Models.Data;

namespace YAHRA.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<employee> GetEmployees(SortingEnum? sortingOrder, int? pageSize, int? page, SearchModel searchModel);

        employee GetEmployee(int id);

        employee UpdateEmployee(int id, employee employeeNew);
        bool DeleteEmployee(int id);
        employee CreateEmployee(employee employeeNew);
    }
}