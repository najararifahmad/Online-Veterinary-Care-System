using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        VCDbContext _context = new VCDbContext();

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Mobile == username);
        }

        public ApiResponse RegisterUser(User user)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var _user = _context.Users.Where(u => u.Email == user.Email).SingleOrDefault();
                    if (_user != null)
                        return new ApiResponse
                        {
                            Added = false,
                            Message = "Email already exists"
                        };
                    _user = _context.Users.Where(u => u.Mobile == user.Mobile).FirstOrDefault();
                    if (_user != null)
                        return new ApiResponse
                        {
                            Added = false,
                            Message = "Mobile No. already exists"
                        };

                    if (user.Role.Equals("Doctor"))
                    {
                        _context.Notifications.Add(new Notification
                        {
                            ID = Guid.NewGuid(),
                            NotificationTitle = "A doctor has registered.",
                            NotificationText = "A doctor has registered on the platform.",
                            Link = "/admin/EditUser?username=" + user.Mobile,
                            AddedOn = DateTime.Now,
                            Read = false,
                            Username = "admin"
                        });
                    }

                    _context.Users.Add(user);
                    _context.SaveChanges();
                    transaction.Commit();

                    return new ApiResponse
                    {
                        Added = true,
                        Message = "Registration done successfully."
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new ApiResponse
                    {
                        Added = false,
                        Message = "Error occured. Please try again..."
                    };
                }
            }

        }
    }
}
