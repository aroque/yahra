using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHRA_WebApp.Models.Dto;
using YAHRA_WebApp.ViewModels;

namespace YAHRA_WebApp.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeListViewModel> GetEmployees(string sortingOrder, int? pageSize, int? page, string department, string employeeStatus);

        Task<EmployeeFormViewModel> GetEmployee(int id);

        Task<bool> UpdateEmployee(int id, EmployeeFormViewModel employeeNew);
        Task<bool> DeleteEmployee(int id);

        Task<bool> CreateEmployee(EmployeeFormViewModel employeeNew);
        Task<EmployeeFormViewModel> GetEmployeeDefaultInfo();
    }
}
