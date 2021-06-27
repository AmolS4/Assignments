using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmwrkUserStory
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

	public class Category
	{
		public bool createasync(string catname)
		{
			if (string.IsNullOrEmpty(catname))
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
	public class User
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}


	public class UsersDb : List<User>
	{
		public UsersDb()
		{
			Add(new User() { UserName = "Mahesh", Password = "mahesh" });
			Add(new User() { UserName = "Tejas", Password = "tejas" });
			Add(new User() { UserName = "Vivek", Password = "vivek" });
			Add(new User() { UserName = "Satish", Password = "satish" });
			Add(new User() { UserName = "Mukesh", Password = "mukesh" });
			Add(new User() { UserName = "Sandeep", Password = "sandeep" });
			Add(new User() { UserName = "Vinay", Password = "vinay" });
			Add(new User() { UserName = "Tushar", Password = "tusjar" });
		}
	}




}
