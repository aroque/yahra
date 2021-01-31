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
    public class EmployeeStatusService : IEmployeeStatusService
    {
        private IEmployeeStatusRepository _employeeStatusRepository;
        private IMapper _mapper;

        public EmployeeStatusService(IEmployeeStatusRepository employeeStatusRepository, IMapper mapper)
        {
            _employeeStatusRepository = employeeStatusRepository;
            _mapper = mapper;
        }
        public List<EmployeeStatus> GetEmployeeStatuses()
        {
            return _mapper.Map<List<employee_status>, List<EmployeeStatus>>(_employeeStatusRepository.GetEmployeeStatuses());
        }
    }
}