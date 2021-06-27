using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnitTest.Models;
namespace UnitTest.DataAccessLayer
{
     public class Registration
    {

        private DotnetunittestContext context;

        public Registration()
        {
            context = new DotnetunittestContext();
        }


        public async Task<Roles> CreateAsyncRole(Roles entity)
        {
            try
            {
                var res = await context.Roles.AddAsync(entity);
               
                await context.SaveChangesAsync();
                return res.Entity; // newly created entity object
            }
            catch (Exception ex)
            {
                // throw
                throw ex;
            }
        }
        public async Task<Users> CreateAsyncUser(Users model)
        {
            try
            {
                
                var result = await context.Users.AddAsync(model);
                await context.SaveChangesAsync();
                return result.Entity; // newly created entity object
            }
            catch (Exception ex)
            {
                // throw
                throw ex;
            }
        }



        
        public async Task<Users> AssignRoleToUser(Users model)
        {
            try
            {

                var result = await context.Users.AddAsync(model);
                await context.SaveChangesAsync();
                return result.Entity; // newly created entity object
            }
            catch (Exception ex)
            {
                // throw
                throw ex;
            }
        }



        public bool CheckRollName(string rname)
        {
            Rolesdb db = new Rolesdb();
           
            if (string.IsNullOrEmpty(rname))
            {
                return true;
            }
           
            if (rname.Contains("^[0-9]"))
            {
                return false;
            }

            return false;
        }

        //public bool RollExist(string rname)
        //{

        //    Rolesdb db = new Rolesdb();

        //    string name= db.Find(rname);


        //    if (rname.Contains(rname))
        //    {
        //        return false;
        //    }


        //    return true;
        //}

        public bool CheckUserName(string uname)
        {
           

            if (string.IsNullOrEmpty(uname))
            {
                return false;
            }

            if (uname.Contains("^[0-9]"))
            {
                return false;
            }
            if (uname.Length <= 8 && uname.Length >= 20)
            {
                return false;
            }
            return true;
        }

        public  bool checkemail(string email)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-
         9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
         RegexOptions.CultureInvariant | RegexOptions.Singleline);



            if (regex.IsMatch(email))
            {
                return true;
            }

            return false;
        }



    }
}
