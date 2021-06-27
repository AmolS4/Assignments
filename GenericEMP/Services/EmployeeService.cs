using System;
using System.Collections.Generic;
using System.Text;
using GenericEMP.Model;

namespace GenericEMP.Services
{
	public class EmployeeService : IService<Employee, int>
	{
		private EmployeesDb database;

		public EmployeeService()
		{
			database = new EmployeesDb();
		}

		public IEnumerable<Employee> Create(Employee model)
		{
			database.Add(model);
			return database;
		}

		public bool Delete(int id)
		{
			
			var emp = database.Find(x => x.EmpNo == id);

			if (emp != null)
			{

				return database.Remove(emp);
			}
			else
			{
				return false;
			}
		}

		//public IEnumerable<Employee> Get()
		//{
		//	return database;
		//}

		public void Get()
		{
			foreach (var item in database)
			{
				Console.WriteLine($"{item.EmpNo} {item.EmpName} { item.Salary}  {item.DeptNo}");
			}

		}

		public Employee Get(int id)
		{
			var emp = database.Find(e => e.EmpNo == id);
            Console.WriteLine($"{emp.EmpNo} {emp.EmpName} {emp.Salary} {emp.DeptNo}");
			
			//emp = emp.EmpNo;
			
			//emp.DeptNo
			return emp;
		}

        public void Update(int id, Employee model)
        {
			var emp = database.Find(x => x.EmpNo == id);
			emp.EmpName = model.EmpName;
			emp.Salary = model.Salary;
			Console.WriteLine("Updated Employee details :: ");
			Console.WriteLine($"{emp.EmpName} {emp.Salary}");
		}


		


		




	}
}
