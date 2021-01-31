using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHRA.Models.API;
using YAHRA.Models.Data;

namespace YAHRA.Repositories.Interfaces
{
    public interface IEmployeeStatusRepository
    {
        List<employee_status> GetEmployeeStatuses();
    }
}
