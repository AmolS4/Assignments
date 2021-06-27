using System;
using System.Collections.Generic;
using System.Text;

namespace GenericEMP.Model
{
	public abstract class Model
	{ }


	public class Department : Model
	{
		public int DeptNo { get; set; }
		public string DeptName { get; set; }
		public string Location { get; set; }
		public int Capacity { get; set; }
	}

	public class Employee : Model
	{
		public int EmpNo { get; set; }
		public string EmpName { get; set; }
		public int Salary { get; set; }
		public int DeptNo { get; set; }
	}

}
