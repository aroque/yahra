using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA.Models.API;
using YAHRA.Models.Data;

namespace YAHRA.Mappers
{
    public class EmployeeToEmployeeDtoMapperProfile : Profile
    {
        public EmployeeToEmployeeDtoMapperProfile()
        {
            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();
            CreateMap<Department, department>();
            CreateMap<EmployeeStatus, employee_status>();
            CreateMap<Employee, employee>();
        }
    }
}