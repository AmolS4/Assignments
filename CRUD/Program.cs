using CRUD.Models;
using CRUD.Services;
using CRUD.Validators;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD
{
   public class Program
    {
       static IService<Department, int> deptserv = new DepartmentService();
       static IService<Employee, int> empserv = new EmployeeService();
      static  Department dept = new Department();
      static Employee emp = new Employee();
        //static EmployeeDb employees = new EmployeeDb();
        static async Task Main(string[] args)
        {


            while (true)
            {

                Console.WriteLine("Please select below Menu");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Get All Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4.Update Employee Record");
                Console.WriteLine("5.List Employees Group by Department Names");
                Console.WriteLine("6.Department List");
                Console.WriteLine("7.Add Department");
                Console.WriteLine("8.Edit Department");
                Console.WriteLine("9.Delete Department");
                Console.WriteLine("10. Exit");



                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        //Console.WriteLine("Enter the Employee ID");
                        //int empid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Employee Name");
                        string ename = Console.ReadLine();
                        Console.WriteLine("Enter the Employee Salary");
                        int sal = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Dept No 1,2,3,4,5");
                        int dno = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Designation Name");
                        string dname = Console.ReadLine();


                        if (InputValidator.DeptValidator(dept).Count == 0)
                        {
                            var employee = await empserv.CreateAsync(new Employee() { Ename = ename, Salary = sal, DeptNo = dno, Designation = dname });

                        }


                        Console.WriteLine("Employee Added Successfully");
                        break;

                    case 2:
                        Console.WriteLine("List of emp");
                        var emps= await empserv.GetAsync();

                        foreach (var item in emps.ToList())
                        {
                            Console.WriteLine($" {item.EmpNo} {item.Ename} {item.Designation} {item.DeptNo}");
                        }

                        break;

                    case 3:
                        Console.WriteLine("Enter the Employee Id");
                        int id = Convert.ToInt32(Console.ReadLine());

                        var delemp = await empserv.DeleteAsync(id);

                        Console.WriteLine("Employee delete succefully");
                        //foreach (var item in emps)
                        //{
                        //    Console.WriteLine($" {item.EmpNo} {item.Ename} {item.Designation} {item.DeptNo}");
                        //}

                        break;
                    case 4:
                        Console.WriteLine("Enter Employee Id For Edit record");
                        int empid = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter  Name of employee");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Salary of employee");
                        int esalary = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter  Dept No. of employee");
                        int deptno = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter  Designation of employee");
                        string des = Console.ReadLine();


                       
                       await empserv.UpdateAsync(empid, new Employee() { Ename = name, Salary = esalary,DeptNo =deptno,Designation=des });
                        Console.WriteLine("Employee Update succefully");
                        break;



                    case 5:
                        //ListOfEmpByDesignation();
                        //Department dept = new Department();
                        //Employee emp = new Employee();
                      

                        //empserv.ListOfEmpByDesignation();


                        break;
                    case 6:

                        Console.WriteLine("List of Department");
                        var dep = await deptserv.GetAsync();

                        foreach (var item in dep.ToList())
                        {
                            Console.WriteLine($" {item.DeptNo} {item.DeptName} {item.Location}");
                        }

                        break;
                    case 7:

                        Console.WriteLine("Enter the Department Name");
                        string depname = Console.ReadLine();
                        Console.WriteLine("Enter the department location");
                        string loc = Console.ReadLine();
                        if (InputValidator.DeptValidator(dept).Count == 0)
                        {
                            await deptserv.CreateAsync(new Department() { DeptName = depname, Location = loc });
                            Console.WriteLine("Department Added Successfully");
                        }
                       
                        break;
                    case 8:

                        Console.WriteLine("Enter dept NO For Edit record");
                        int deptid = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Dept Name");
                        string deptname = Console.ReadLine();
                        Console.WriteLine("Enter new location of department");
                        string location =Console.ReadLine();

                        await deptserv.UpdateAsync(deptid, new Department() { DeptName = deptname, Location = location });
                        Console.WriteLine("Department Update succefully");
                        break;
                    case 9:
                        Console.WriteLine("Enter the Dept No");
                        int did = Convert.ToInt32(Console.ReadLine());

                        await deptserv.DeleteAsync(did);

                        Console.WriteLine("Dept delete succefully");
                        break;

                    case 10:
                        Console.WriteLine("Are you sure to Exit the Application");
                        Console.WriteLine("Press Enter To  Key To Confirm!");
                        Console.ReadLine();
                        System.Environment.Exit(1);
                        break;

                    
                    //case 11:
                    //    Employee emp = new Employee();
                    //    var result = from e in emp
                    //                 group e by e.DeptId into DeptGroup
                    //                 select new
                    //                 {
                    //                     DeptId = DeptGroup.Key,
                    //                     Designation = DeptGroup.Max(e => e.Designation)
                    //                 };
                    //    break;

                }


                


            }

           

        }

        //private static async Task PrintEmployeesByDeptName(string dname)
        //{
        //    Employee employees = new Employee();
        //    var result = employees.Where(e => e.Deptname == dname)
        //                          .OrderByDescending(e => e.EmpId)
        //                          .Select(e => e);



        //    foreach (var item in result)
        //    {
        //        Console.WriteLine($"{item.EmpId} {item.Empname} {item.Salary} {item.Designation} {item.Deptname} {item.DeptId}");
        //    }
        //}


        //static void ListOfEmpByDesignation()
        //{
        //    Employee emp = new Employee();
        //    var result = from e in emp
        //                 group e by e.DeptId into DeptGroup
        //                 select new
        //                 {
        //                     DeptId = DeptGroup.Key,
        //                     Designation = DeptGroup.Max(e => e.Designation)
        //                 };
        //    foreach (var item in result)
        //    {
        //        Console.WriteLine($"{item.DeptId}   {item.Designation}");
        //    }
        //}




    }
}
