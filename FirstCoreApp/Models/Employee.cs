using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FirstCoreApp.Models
{
    public partial class Employee
    {
        public int EmpNo { get; set; }
        public string Ename { get; set; }
        public int? Salary { get; set; }
    }
}
