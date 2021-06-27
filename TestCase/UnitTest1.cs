
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest;
using UnitTest.DataAccessLayer;

namespace TestCase
{
	[TestFixture]
	public class UnitTest1
    {
       

		

		[Test]
		public void RollNameTest()
		{
			

			Registration reg = new Registration();
			//string name = "Amol";
			//string testname = "Amol";
			string uname = "Admin";
			var result = reg.CheckRollName(uname);
			Assert.That(result, Is.EqualTo(false));

		}


		//[Test]
		//public void RollExistOrNot()
		//{


		//	Registration reg = new Registration();
		//	//string name = "Amol";
		//	//string testname = "Amol";
		//	string uname = "Admin";
		//	var result = reg.RollExist(uname);
		//	Assert.That(result, Is.EqualTo(false));

		//}



		[Test]
		public void UserNameTest()
		{


			Registration reg = new Registration();
			//string name = "Amol";
			//string testname = "Amol";
			string uname = "Amolsawkar";
			var result = reg.CheckUserName(uname);
			Assert.That(result, Is.EqualTo(true));

		}

		[Test]
		public void EmailTest()
		{


			Registration reg = new Registration();
			//string name = "Amol";
			//string testname = "Amol";
			string email = "Amolsaw@gmail.com";
			var result = reg.checkemail(email);
			Assert.That(result, Is.EqualTo(true));

		}



	}
}
