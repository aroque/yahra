using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHRA.Models.API;
using YAHRA.Models.Data;
using YAHRA.Repositories.Interfaces;

namespace YAHRA.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public List<department> GetDepartments()
        {
            using (var context = new YAHRA_DBEntities())
            {
                return context.departments.ToList<department>();
            }
        }
    }
}
