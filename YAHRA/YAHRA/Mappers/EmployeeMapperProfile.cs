using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA.Models.API;
using YAHRA.Models.Data;

namespace YAHRA.Mappers
{
    public class EmployeeMapperProfile : Profile
    {
        public EmployeeMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            CreateMap<department, Department>().ReverseMap();
            CreateMap<employee_status, EmployeeStatus>().ReverseMap();
            CreateMap<employee, Employee>().ReverseMap();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}