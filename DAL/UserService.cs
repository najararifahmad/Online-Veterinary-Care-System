using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserService
    {
        public User ValidateUser(string email, string password)
        {
            // Here you can write the code to validate
            // User from database and return accordingly
            // To test we use dummy list here
            var _context = new VCDbContext();
            var user = _context.Users.FirstOrDefault(x => (x.Email == email || x.Mobile == email) && x.Password == password);
            return user;
        }


    }
}
