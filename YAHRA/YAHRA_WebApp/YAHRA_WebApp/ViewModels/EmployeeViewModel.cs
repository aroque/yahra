using System;
using System.ComponentModel.DataAnnotations;

namespace YAHRA_WebApp.ViewModels
{
    public class EmployeeViewModel
    {

        [Display(Name = "Employee Nr.")]
        public int Id { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string Email { get; set; }

        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public DepartmentViewModel Department { get; set; }
        public EmployeeStatusViewModel EmployeeStatus{ get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {Surname}";
            }
        }
    }
}