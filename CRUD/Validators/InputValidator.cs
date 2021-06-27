using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Validators
{
	public static class InputValidator
	{
		public static List<string> DeptValidator(Department department)
		{
			List<string> errors = new List<string>();
			int? no = null;
			if (department.DeptNo == no)
				errors.Add("DeptNo is Must");
			else if (department.Location == string.Empty ||  department.Location== null)
				errors.Add("Location is Must");

			return errors;
		}

		public static List<string> DeptValidator(Employee employee)
		{
			List<string> errors = new List<string>();
			int? no = null;
			if (employee.EmpNo == no)
				errors.Add("Emp No is Must");
			else if (employee.DeptNo == no)
				errors.Add("Dept no is Must");

			return errors;
		}




	}

	

}
