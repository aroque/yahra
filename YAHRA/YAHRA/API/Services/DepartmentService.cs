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
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;
        private IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public List<Department> GetDepartments()
        {
            return _mapper.Map<List<department>, List<Department>>(_departmentRepository.GetDepartments());
        }
    }
}