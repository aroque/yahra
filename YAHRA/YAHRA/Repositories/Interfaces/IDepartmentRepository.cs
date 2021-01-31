using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHRA.Models.Data;

namespace YAHRA.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        List<department> GetDepartments();
    }
}
