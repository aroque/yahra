using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YAHRA.Models.API
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeStatusId { get; set; }
        public Department Department { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
    }
}