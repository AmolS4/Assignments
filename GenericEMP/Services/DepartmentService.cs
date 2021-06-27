using System;
using System.Collections.Generic;
using System.Text;
using GenericEMP.Model;
using System.Linq;

namespace GenericEMP.Services
{
	public class DepartmentService : IService<Department, int>
	{
		private DepartmentsDb database;

		public DepartmentService()
		{
			database = new DepartmentsDb();
		}

		public IEnumerable<Department> Create(Department model)
		{
			database.Add(model);
			return database;
		}

		

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		
		public void Get()
		{
			foreach (var item in database)
			{
				Console.WriteLine($"{item.DeptNo} {item.DeptName} { item.Location} { item.Capacity}");
			}
		}
		public Department Get(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(int id, Department model)
		{
			throw new NotImplementedException();
		}
	}
}
