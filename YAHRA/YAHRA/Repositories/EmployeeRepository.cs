using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA.Models;
using YAHRA.Models.Data;
using YAHRA.Repositories.Interfaces;
using System.Data.Entity;

namespace YAHRA.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<employee> GetEmployees()
        {
            using (var context = new YAHRA_DBEntities())
            {
                return context.employees
                    .Include(e=>e.department)
                    .Include(e=>e.employee_status)
                    .ToList<employee>();
            }
        }

        public employee GetEmployee (int employeeId)
        {
            using (var context = new YAHRA_DBEntities())
            {
                return context.employees
                    .Include(e => e.department)
                    .Include(e => e.employee_status)
                    .SingleOrDefault(e => e.id == employeeId);
            }
        }

        public bool UpdateEmployee(employee employeeNew)
        {
            using (var context = new YAHRA_DBEntities())
            {
                var employee = context.employees.SingleOrDefault(e => e.id == employeeNew.id);

                if(employee != null)
                {
                    employee.first_name = employeeNew.first_name;
                    employee.surname = employeeNew.surname;
                    employee.department_id = employeeNew.department_id;
                    employee.employee_status_id = employeeNew.employee_status_id;
                    employee.date_of_birth = employeeNew.date_of_birth;
                    context.Entry<employee>(employee).State = EntityState.Modified;

                    return context.SaveChanges() > 0;
                }

                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var context = new YAHRA_DBEntities())
            {
                var employeeToDel = context.employees.SingleOrDefault(e => e.id == id);

                if (employeeToDel != null)
                {
                    context.employees.Remove(employeeToDel);

                    return context.SaveChanges() > 0;
                }

                return false;
            }
        }

        public bool CreateEmployee(employee employeeNew)
        {
            using (var context = new YAHRA_DBEntities())
            {
                context.employees.Add(employeeNew);
                return context.SaveChanges() > 0;
            }
        }
    }
}