using System;
using System.Threading.Tasks;
using ThreadingAssignment.Model;

namespace ThreadingAssignment
{
   public class Program
    {
        static void Main(string[] args)
        {


            EmployeesDb database = new EmployeesDb();



            Console.WriteLine("Tax of Manager");
            for (int i = 0; i < database.Count; i++)
            {
                ProcessTax.ManagerTax(database[i]);
                Console.WriteLine($"Tax for {database[i].EmpNo} {database[i].Designation }");
            }
            Console.WriteLine("Tax of Engineer");
            for (int i = 0; i < database.Count; i++)
            {
                ProcessTax.EngineerTax(database[i]);
                Console.WriteLine($"Tax for {database[i].EmpNo} {database[i].Designation }");
            }
            Console.WriteLine("Tax of Lead");
            for (int i = 0; i < database.Count; i++)
            {
                ProcessTax.LeadTax(database[i]);
                Console.WriteLine($"Tax for {database[i].EmpNo} {database[i].Designation }");
            }
            Console.WriteLine("Tax of Programmer");
            for (int i = 0; i < database.Count; i++)
            {
                ProcessTax.programmingTax(database[i]);
                Console.WriteLine($"Tax for {database[i].EmpNo} {database[i].Designation }");
            }



            Console.ReadLine();


        }

        public static class ProcessTax
        {
            public static async Task<Employee> ManagerTax(Employee e)
            {



                if (e.DeptNo == 10)
                {
                  //  e.Tax = await (e.Salary * Convert.ToDecimal(3.0));
                    e.Tax = await (Convert.ToDecimal(e.Salary) * Convert.ToDecimal(3.0));
                    Console.WriteLine(e.Tax);
                }
                else
                {
                    Console.WriteLine("No tax");
                }
                return e;



            }



            public static Employee EngineerTax(Employee e)
            {



                if (e.DeptNo == 10)
                {
                    e.Tax = e.Salary * Convert.ToDecimal(2.0);
                    Console.WriteLine(e.Tax);
                }
                else
                {
                    Console.WriteLine("No tax");
                }
                return e;



            }
            public static Employee LeadTax(Employee e)
            {



                if (e.DeptNo == 10)
                {
                    e.Tax = e.Salary * Convert.ToDecimal(2.8);
                    Console.WriteLine(e.Tax);
                }
                else
                {
                    Console.WriteLine("No tax");
                }
                return e;



            }
            public static Employee programmingTax(Employee e)
            {



                if (e.DeptNo == 10)
                {
                    e.Tax = e.Salary * Convert.ToDecimal(2.0);
                    Console.WriteLine(e.Tax);
                }
                else
                {
                    Console.WriteLine("No tax");
                }
                return e;



            }



        }



    }
}
