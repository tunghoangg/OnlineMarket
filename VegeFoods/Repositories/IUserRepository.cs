using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        string Registor(User newUser);
        User Login(string username, string password);   
        User FindUserById(int userId);
        void UpdateUser(User u);
        List<User> GetUsers();
        List<User> SearchUserByName(string name);
        User SearchUserByUserName(string userName);
    }
}
