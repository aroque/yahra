using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA.API.Services.Interfaces;
using YAHRA.Models.API;
using YAHRA.Models.Data;
using YAHRA.Repositories.Interfaces;

namespace YAHRA.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private IMapper _mapper;

        public EmployeeService (IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public bool CreateEmployee(Employee employeeNew)
        {
            return _employeeRepository.CreateEmployee(_mapper.Map<Employee, employee>(employeeNew));
        }

        public bool DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        public Employee GetEmployee(int id)
        {
            return _mapper.Map<employee, Employee>(_employeeRepository.GetEmployee(id));
        }

        public List<Employee> GetEmployees()
        {
            return _mapper.Map<List<employee>, List<Employee>>(_employeeRepository.GetEmployees());
        }

        public bool UpdateEmployee(Employee employeeNew)
        {
            return _employeeRepository.UpdateEmployee(_mapper.Map<Employee, employee>(employeeNew));
        }
    }
}