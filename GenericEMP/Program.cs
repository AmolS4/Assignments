using System;
using GenericEMP.Model;
using GenericEMP.Services;
using System.Linq;
namespace GenericEMP
{
    class Program
    {
        static EmployeesDb emp = new EmployeesDb();
        static DepartmentsDb dept = new DepartmentsDb();
        IService<Employee, int> empServ = new EmployeeService();

        static void Main(string[] args)
        {
           
            Console.Clear();
            Console.WriteLine("Please select below Menu");
            Console.WriteLine("Option 1: Show All Employee");
           

            Console.WriteLine("Option 2: Add Employee");
            Console.WriteLine("Option 3: Edit Employee");
            Console.WriteLine("Option 4: Delete Employee");
            //Console.WriteLine("Option 2: Show All Department");
            // Console.WriteLine("Option 4: Add Department");

           
            Console.WriteLine("Option 5: Highest salary Deptartment wise");
            Console.WriteLine("Option 6: Employee List Deptartment wise");
            Console.WriteLine("Option 7: Add Department");
            Console.WriteLine("Option 8: List Of Department");
            Console.WriteLine("Option 8: Increament  employee salary ");
            Console.WriteLine("Option 10: Exit");

            string options = Console.ReadLine();
           
            switch (options)
            {
                case "1":
                    ShowAllEmp();
                    break;
                case "2":
                    AddEmp();
                    break;
                case "3":
                    EditEmp();

                    break;
                case "4":
                    DeletetEmp();
                    break;


                case "5":
                    GetMaxSalary();
                        break;
                case "6":
                    ShowEmpDeptWise();
                    break;
                case "7":
                    AddDept();
                    break;
                case "8":
                    DeptList();
                    break;
                case "9":
                    IncSalary();
                    break;
                case "10":
                    Exit();
                    break;

                    
            }
            


            static void ShowAllEmp() {

                IService<Employee, int> empservice = new EmployeeService();
                empservice.Get();

                //foreach (var item in employees)
                //{
                //    Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary}{item.DeptNo}");
                //}
                Console.ReadLine();
            }



            


            static void AddEmp()
            {
                IService<Employee, int> empServ = new EmployeeService();

                Console.WriteLine("Enter Employee No");
                string EmpNo = Console.ReadLine();
                Console.WriteLine("Enter Employee Name");
                string EmpName = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary");
                string Salary = Console.ReadLine();
                Console.WriteLine("Enter Employee Dept No");
                int DeptNo = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Customer City");
                string City = Console.ReadLine();

                Employee emp = new Employee();
               
                
                empServ.Create(emp);
               
                Console.WriteLine("Record saved succesfully");
                Console.ReadLine();


            }


            static void EditEmp()
            {

            
              
                IService<Employee, int> empservice = new EmployeeService();

                Console.WriteLine("Enter Employee Id For Edit record");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter  Name and Salary of employee");
                string name = Console.ReadLine();
                int sal = Convert.ToInt32(Console.ReadLine());
                empservice.Update(id, new Employee() { EmpName = name, Salary = sal });

                
               

            }



            static void DeletetEmp()
            {

                IService<Employee, int> empservice = new EmployeeService();

                Console.WriteLine("Enter Employee Id For Delete record");
                int id = Convert.ToInt32(Console.ReadLine());
                if (id != 0)
                {
                    empservice.Delete(id);
                    Console.WriteLine("Employee Deleted Successfully!!!!");
                }
                else
                {
                    Console.WriteLine("You have entered invalid ID");
                }

            }




            static void Exit()
            {

                Console.WriteLine("Are you sure to Exit the Application");
                Console.WriteLine("Press Enter To  Key To Confirm!");
                Console.ReadLine();
                System.Environment.Exit(1);
            }




            static void GetMaxSalary()
            {
                EmployeesDb emp = new EmployeesDb();
                //Department dept = new Department();
                Console.WriteLine();
                Console.WriteLine("Highest salary Deptartment wise");
                var result = from e in emp
                             from d in dept
                             where d.DeptNo == e.DeptNo
                             group e by e.DeptNo into DeptGroup
                             select new
                             {
                                 DeptNo = DeptGroup.Key,
                                 Salary = DeptGroup.Max(e => e.Salary)
                             };
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.DeptNo} {item.Salary}");
                }
                Console.ReadLine();
            }



            static void ShowEmpDeptWise()
            {
                DepartmentsDb dept = new DepartmentsDb();
                Console.WriteLine("Employee List Deptartment wise");
                var result = from d in dept
                             from e in emp
                             where d.DeptNo == e.DeptNo
                             select new
                             {
                                 EmpNo = e.EmpNo,
                                 EmpName = e.EmpName,
                                 Salary = e.Salary,
                                 DeptName = d.DeptName,
                                 Location = d.Location
                             };



                foreach (var item in result)
                {
                    Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.DeptName} {item.Location}");
                }
                Console.ReadLine();
            }


            static void AddDept()
            {

                IService<Department, int> deptServ = new DepartmentService();
                Console.WriteLine("Enter the Department Code");
                int deptid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Department Name");
               string dname = Console.ReadLine();
                Console.WriteLine("Enter the Department Location");
                string location = Console.ReadLine();
                Console.WriteLine("Enter the Department Capacity");
                int capcity = Convert.ToInt32(Console.ReadLine());

                if (checkingCapicityAsperDepartment(deptid) == dept.Capacity)
                {
                    Console.WriteLine("Capaity is full !! You may choose other Department");
                }
                else
                {
                    deptServ.Create(new Department() { DeptNo = deptid, DeptName = dname, Location = location, Capacity = capcity });
                    Console.WriteLine("Department added successfully");
                }
            }
            static int checkingCapicityAsperDepartment(int depid)
            {
                DepartmentsDb dept = new DepartmentsDb();

                var dept1 = dept.Find(x => x.DeptNo == depid);
                Console.WriteLine(dept1.Capacity);
                return depid;
            }

            static void DeptList()
            {
                IService<Department, int> deptServ = new DepartmentService();

                Console.WriteLine("List Of dept are Displaying");
                deptServ.Get();
                
            }
            static void IncSalary()
            {
                IService<Department, int> deptServ = new DepartmentService();
                IService<Employee, int> empservice = new EmployeeService();
                EmployeesDb empd = new EmployeesDb();

                Console.WriteLine("Enter the Employee id whose salary wants to increase");
                int empid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter New Name as well Salary of employee");
               string  name = Console.ReadLine();
                Console.WriteLine("Enter previous salry");
               int sal = Convert.ToInt32(Console.ReadLine());

                var emp = empd.Find(x => x.EmpNo == empid);

                int newsalary = sal + (sal * 15) / 100;

                Console.WriteLine($"New Salary :-  {newsalary}");
                empservice.Update(empid, new Employee() { EmpName = name, Salary = newsalary });
                Console.WriteLine("Salary is successfully updated");

            }





           
        }
    }
}
