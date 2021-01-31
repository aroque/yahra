using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA.API.Services.Interfaces;
using YAHRA.Models;
using YAHRA.Models.API;
using YAHRA.Models.Data;
using YAHRA.Repositories.Interfaces;
using YAHRA.SMTPClient.Interface;

namespace YAHRA.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private IMapper _mapper;
        private IBasicSmtpClient _smtpClient;

        public EmployeeService (IEmployeeRepository employeeRepository, IMapper mapper, IBasicSmtpClient smtpClient)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _smtpClient = smtpClient;
        }

        public Employee CreateEmployee(Employee employeeNew)
        {
            employee empAux = _employeeRepository.CreateEmployee(_mapper.Map<Employee, employee>(employeeNew));

            var result = _mapper.Map<employee, Employee>(_employeeRepository.GetEmployee(empAux.id));

            if (result != null)
            {
                try
                {
                    _smtpClient.SendEmail(result.Email, "User Created", $"Hi {result.FirstName}. Your user was created with the status {result.EmployeeStatus.Name}");
                }
                catch(Exception e)
                {
                    //Log
                }

            }

            return result;
        }

        public bool DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        public Employee GetEmployee(int id)
        {
            return _mapper.Map<employee, Employee>(_employeeRepository.GetEmployee(id));
        }

        public List<Employee> GetEmployees(SortingEnum? sortingOrder, int? pageSize, int? page, string filters)
        {

            try
            {
                SearchModel searchModel = (filters != null) ? JsonConvert.DeserializeObject<SearchModel>(filters) : null;

                return _mapper.Map<List<employee>, List<Employee>>(_employeeRepository.GetEmployees(sortingOrder, pageSize, page, searchModel));
            }
            catch(Exception ex)
            {
                //Log
                return null;
            }
        }

        public Employee UpdateEmployee(int id, Employee employeeNew)
        {
            employee empAux = _employeeRepository.UpdateEmployee(id, _mapper.Map<Employee, employee>(employeeNew));
            var result = _mapper.Map<employee, Employee>(_employeeRepository.GetEmployee(empAux.id));

            if (result != null)
                try
                {
                    _smtpClient.SendEmail(employeeNew.Email, "User Modified", $"Hi {employeeNew.FirstName}. Your user account was modified. The current status is {employeeNew.EmployeeStatus.Name}");

                }
                catch(Exception ex) { 
                    //Log
                }

            return result;
        }
    }
}