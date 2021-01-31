using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHRA.Models.API;

namespace YAHRA.API.Services.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
    }
}
