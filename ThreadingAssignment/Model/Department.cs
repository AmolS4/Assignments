using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadingAssignment.Model
{
    public abstract class Model
    { }

	public class Employee : Model
	{
		public int EmpNo { get; set; }
		public string EmpName { get; set; }
		public int Salary { get; set; }
		public int DeptNo { get; set; }
        public string Designation { get; set; }
        public string DeptName { get; set; }

        public decimal Tax { get; set; }

        

    }

}
