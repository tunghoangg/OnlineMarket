using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public string Registor(User newUser)
        {
            return UserDAO.Registor(newUser);
        }
        public User Login(string username, string password)
        {
            return UserDAO.Login(username, password);
        }
        public User FindUserById(int userId)
        {
            return UserDAO.FindUserById(userId);
        }

        public List<User> GetUsers()
        {
            return UserDAO.GetUsers();
        }

        public void UpdateUser(User u)
        {
            UserDAO.UpdateUser(u);
        }

        public List<User> SearchUserByName(string name)
        {
            return UserDAO.SearchUserByName(name);
        }

        public User SearchUserByUserName(string userName)
        {
            return UserDAO.SearchUserByUserName(userName);
        }
    }
}
