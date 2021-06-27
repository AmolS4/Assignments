using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Models;

namespace UnitTest.Validator
{
	public static class InputValidator
	{
		static Users use = new Users();
		public static bool reguser(Users user)
		{

            if (user.UserName.Contains("") && user.UserName == null)
            {
				return false;
            }
            if (user.UserName.Contains("^[0-9]"))
            {
				return false;
            }
			if (user.UserName.Length <= 8 && user.UserName.Length >= 20)
			{
				return false;
			}
			return true;
		}

		//public static List<string> reguser1(Users user)
		//{
		//	List<string> errors = new List<string>();
		//	int? no = null;
		//	if (user.UserName.Contains("") && user.UserName == null  && user.UserName.Length <= 8 && user.UserName.Length >= 20)
		//		errors.Add("please insert valid user name");
			

		//	return errors;
		//}



		public static bool checkemail(string email)
		{

			if (email.Contains(@" ^ ([\w\.\-] +)@([\w\-] +)((\.(\w){ 2,3})+)$"))
			{
				return false;
			}
			
			return true;
		}

		public static bool checkpassword(Users user)
		{

			if(user.Password.Length > 6 && user.Password.Length < 8 && user.Password.Contains(@"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/"))
			{
				return true;
			}

			return false;
		}


		public static bool confirmpassword(string password1, string password2)
		{
			if (password1.Equals(password2))
			{
				return true;
			}
			return false;
		}


		public static bool checkingRolesName(Roles role)
		{
			if (role.RoleName != null)
			{
				return true;
			}
			if (role.RoleName == "^[A-Z]")
			{
				return true;
			}
			return false;
		}



	}
}
