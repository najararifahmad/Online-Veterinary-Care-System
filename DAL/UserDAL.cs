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

        public IEnumerable<User> GetDoctors()
        {
            return _context.Users.Where(u => u.Role == "Doctor").OrderByDescending(u => u.AddedOn).ToList();
        }
        public IEnumerable<User> GetActiveDoctors()
        {
            return _context.Users.Where(u => u.Role == "Doctor" && u.IsActive == true).OrderBy(u => u.Name).ToList();
        }
        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Mobile == username);
        }

        public ApiResponse GenerateAdmin(string password)
        {
            try
            {
                User adminUser = _context.Users.Where(u => u.Mobile == "8715995492").FirstOrDefault();
                if (adminUser != null)
                {
                    _context.Users.Remove(adminUser);
                    _context.SaveChanges();
                }

                User admin = new User
                {
                    ID = Guid.NewGuid(),
                    Name = "Admin",
                    Password = password,
                    Email = "admin@vcare.com",
                    Role = "Admin",
                    Mobile = "8715995492",
                    IsActive = true
                };

                _context.Users.Add(admin);
                _context.SaveChanges();

                return new ApiResponse
                {
                    Added = true,
                    Message = "Admin generated successfully"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Added = false,
                    Message = "Error occured. Please try again..."
                };
            }
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
                            Link = "/admin/User/" + user.Mobile,
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

        public ApiResponse ApproveDoctor(string mobile)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Mobile == mobile);
                if(user != null)
                {
                    if (user.IsActive)
                    {
                        return new ApiResponse
                        {
                            Added = false,
                            Message = "Doctor approved already."
                        };
                    }

                    user.IsActive = true;
                    _context.SaveChanges();
                    return new ApiResponse
                    {
                        Added = true,
                        Message = "Doctor approved successfully."
                    };
                }
                return new ApiResponse
                {
                    Added = false,
                    Message = "Doctor not found. Please try again..."
                };
            }
            catch (Exception)
            {
                return new ApiResponse
                {
                    Added = false,
                    Message = "Error occured. Please try again..."
                };
            }
        }

        public ApiResponse RejectDoctor(string mobile)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Mobile == mobile);
                if (user != null)
                {
                    if (!user.IsActive)
                    {
                        return new ApiResponse
                        {
                            Added = false,
                            Message = "Doctor rejected already or not approved yet."
                        };
                    }

                    user.IsActive = false;
                    _context.SaveChanges();
                    return new ApiResponse
                    {
                        Added = true,
                        Message = "Doctor rejected successfully."
                    };
                }
                return new ApiResponse
                {
                    Added = false,
                    Message = "Doctor not found. Please try again..."
                };
            }
            catch (Exception)
            {
                return new ApiResponse
                {
                    Added = false,
                    Message = "Error occured. Please try again..."
                };
            }
        }

        public ApiResponse SaveDoctorVerificationImages(User user)
        {
            try
            {
                var _user = _context.Users.FirstOrDefault(u => u.Mobile == user.Mobile);
                if (_user != null)
                {
                    _user.IdentityCardImagePath = user.IdentityCardImagePath;
                    _user.AadharCardImagePath = user.AadharCardImagePath;
                    _context.SaveChanges();
                    return new ApiResponse
                    {
                        Added = true,
                        Message = "Verification documents uploaded successfully. Please wait for the admin to approve your account."
                    };
                }
                return new ApiResponse
                {
                    Added = false,
                    Message = "Error occured. Please try again..."
                };
            }
            catch (Exception)
            {
                return new ApiResponse
                {
                    Added = false,
                    Message = "Error occured. Please try again..."
                };
            }
        }
    }
}
