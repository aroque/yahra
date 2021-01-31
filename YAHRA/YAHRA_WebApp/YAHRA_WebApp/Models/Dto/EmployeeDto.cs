using System;

namespace YAHRA_WebApp.Models.Dto
{

    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeStatusId { get; set; }
        public DepartmentDto Department { get; set; }
        public EmployeeStatusDto EmployeeStatus { get; set; }
    }
}