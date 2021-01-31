using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA_WebApp.Models.Dto;
using YAHRA_WebApp.ViewModels;

namespace YAHRA_WebApp.Mappers
{
    public class EmployeeDtoToEmployeeMapperProfile : Profile
    {
        public EmployeeDtoToEmployeeMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            CreateMap<DepartmentDto, DepartmentViewModel>().ReverseMap();
            CreateMap<EmployeeStatusDto, EmployeeStatusViewModel>().ReverseMap();
            CreateMap<EmployeeDto, EmployeeViewModel>().ReverseMap();
        }
    }
}