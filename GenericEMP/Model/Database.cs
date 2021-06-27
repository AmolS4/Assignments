using System;
using System.Collections.Generic;
using System.Text;

namespace GenericEMP.Model
{
	public class DepartmentsDb : List<Department>
	{
		public DepartmentsDb()
		{
			Add(new Department() { DeptNo = 10, DeptName = "IT", Location = "Pune", Capacity = 100 });
			Add(new Department() { DeptNo = 20, DeptName = "COMP", Location = "Pune", Capacity = 100 });
			Add(new Department() { DeptNo = 30, DeptName = "MECH", Location = "Pune", Capacity = 100 });
		}
	}

	public class EmployeesDb : List<Employee>
	{
		public EmployeesDb()
		{
			Add(new Employee() { EmpNo = 10, EmpName = "Amol", Salary = 20000, DeptNo = 10 });
			Add(new Employee() { EmpNo = 20, EmpName = "sachin", Salary = 30000, DeptNo = 10 });
			Add(new Employee() { EmpNo = 30, EmpName = "pravin", Salary = 35000, DeptNo = 20 });
			Add(new Employee() { EmpNo = 40, EmpName = "anand", Salary = 40000, DeptNo = 20 });
			Add(new Employee() { EmpNo = 50, EmpName = "ganesh", Salary = 45000, DeptNo = 30 });
		}
	}
}
