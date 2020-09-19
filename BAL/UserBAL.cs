using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class UserBAL
    {
        UserDAL _dal = new UserDAL();
        public User GetUserByUsername(string username)
        {
            return _dal.GetUserByUsername(username);
        }

        public ApiResponse RegisterUser(User user)
        {
            return _dal.RegisterUser(user);
        }
    }
}
