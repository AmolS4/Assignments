using FrmwrkUserStory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MSTestDataSource
{
	[TestClass]
	public class Class1
    {
		private TestContext context;


		public TestContext TestContext
		{
			get { return context; }
			set { context = value; }

		}

		[TestMethod]
		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"C:\citus\SpotDemos\TrainingApps\CS_MS_Test_DataSource\bin\Debug\testdata.csv", "testdata#csv", DataAccessMethod.Sequential), DeploymentItem("testdata.csv"), TestMethod]
		public void TestAuthUserByCSV()
		{
			// Arrange data
			// access test data from the file

			string uname = TestContext.DataRow[0].ToString().Trim();
			string password = TestContext.DataRow[1].ToString().Trim();

			bool result = Convert.ToBoolean(TestContext.DataRow[2].ToString().Trim());
			Category cat = new Category();
			bool actual = cat.createasync(uname);
			Assert.AreEqual(result, actual);
		}


	}
}
