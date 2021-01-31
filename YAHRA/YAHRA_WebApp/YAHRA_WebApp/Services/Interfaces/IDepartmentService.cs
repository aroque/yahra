using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHRA_WebApp.Models.Dto;
using YAHRA_WebApp.ViewModels;

namespace YAHRA_WebApp.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetDepartments();
    }
}
