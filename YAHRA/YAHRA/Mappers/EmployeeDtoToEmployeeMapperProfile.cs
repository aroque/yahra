using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA.Models.API;
using YAHRA.Models.Data;

namespace YAHRA.Mappers
{
    public class EmployeeDtoToEmployeeMapperProfile : Profile
    {
        public EmployeeDtoToEmployeeMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            CreateMap<department, Department>().ReverseMap();
            CreateMap<employee_status, EmployeeStatus>().ReverseMap();
            CreateMap<employee, Employee>().ReverseMap();
        }
    }
}