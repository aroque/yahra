//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YAHRA.Models.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class employee
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public System.DateTime date_of_birth { get; set; }
        public int department_id { get; set; }
        public int employee_status_id { get; set; }
    
        public virtual department department { get; set; }
        public virtual employee_status employee_status { get; set; }
    }
}
