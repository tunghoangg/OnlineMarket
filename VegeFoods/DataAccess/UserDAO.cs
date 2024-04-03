using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO
    {
        public static string Registor(User newUser)
        { string message = "";
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    if(context.Users.Any(x => x.UserName == newUser.UserName))
                    {
                        message = "Username has already existed";
                    }
                    else
                    {

                        context.Add(newUser);  
                        context.SaveChanges();
                        message = "Registor successfully";
                    }
                    return message;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static User Login(string username, string password)
        {
            User u = new User();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    u = context.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return u;
        }
        public static List<User> GetUsers()
        {
            var listUsers = new List<User>();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    listUsers = context.Users.ToList();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            };
            return listUsers;
        }

        public static User FindUserById(int userId)
        {
            User u = new User();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    u = context.Users.SingleOrDefault(x => x.AccountId == userId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return u;
        }

        public static void UpdateUser(User u)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    context.Entry<User>(u).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<User> SearchUserByName(string name)
        {
            List<User> users = new List<User>();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    users = context.Users.Where(x => x.FullName.Contains(name)).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return users;
        }
        public static User SearchUserByUserName(string userName)
        {
            User user = new User();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    user = context.Users.SingleOrDefault(x => x.UserName == userName);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

    }
}
