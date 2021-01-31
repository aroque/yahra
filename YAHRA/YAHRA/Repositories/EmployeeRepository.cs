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
        public List<employee> GetEmployees(SortingEnum? sortingOrder, int? pageSize, int? page, SearchModel searchModel)
        {
            sortingOrder = sortingOrder != null ? sortingOrder : SortingEnum.ID;

            using (var context = new YAHRA_DBEntities())
            {
                IQueryable<employee> employees = context.employees
                    .Include(e=>e.department)
                    .Include(e=>e.employee_status);

                if (searchModel != null && !string.IsNullOrEmpty(searchModel.Department))
                    employees = employees.Where(e => e.department.name == searchModel.Department);

                if (searchModel != null && !string.IsNullOrEmpty(searchModel.EmployeeStatus))
                    employees = employees.Where(e => e.employee_status.name == searchModel.EmployeeStatus);

                switch (sortingOrder)
                {
                    case SortingEnum.ID:
                        employees = employees.OrderBy(e => e.id);
                        break;
                    case SortingEnum.NAME:
                        employees = employees.OrderBy(e => e.first_name).ThenBy(e=>e.surname);
                        break;
                    case SortingEnum.DEPARTMENT_NAME:
                        employees = employees.OrderBy(e => e.department.name);
                        break;
                    case SortingEnum.STATUS:
                        employees = employees.OrderBy(e => e.employee_status.name);
                        break;
                    case SortingEnum.DATE_OF_BIRTH:
                        employees = employees.OrderBy(e => e.date_of_birth);
                        break;
                }

                if (pageSize != null && page != null)
                {
                    employees = employees.Skip((int)((page - 1) * pageSize)).Take((int)pageSize);
                }

                return employees.ToList() ;
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

        public employee UpdateEmployee(int id, employee employeeNew)
        {
            using (var context = new YAHRA_DBEntities())
            {
                var employee = context.employees.SingleOrDefault(e => e.id == id);

                if(employee != null)
                {
                    employee.first_name = employeeNew.first_name;
                    employee.surname = employeeNew.surname;
                    employee.department_id = employeeNew.department_id;
                    employee.employee_status_id = employeeNew.employee_status_id;
                    employee.date_of_birth = employeeNew.date_of_birth;
                    context.Entry(employee).State = EntityState.Modified;

                    return employee;
                }

                return null;
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

        public employee CreateEmployee(employee employeeNew)
        {
            using (var context = new YAHRA_DBEntities())
            {
                var employeeAux = new employee
                {
                    first_name = employeeNew.first_name,

                    surname = employeeNew.surname,
                    date_of_birth = employeeNew.date_of_birth,
                    department_id = employeeNew.department_id,
                    employee_status_id = employeeNew.employee_status_id,
                    email = employeeNew.email

                };
                context.employees.Add(employeeAux);
                context.SaveChanges();

                context.Entry(employeeAux).GetDatabaseValues();
                return employeeAux;
            }
        }
    }
}