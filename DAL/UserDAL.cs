using DAL.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http;
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
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Where(u => u.Role == "User").OrderByDescending(u => u.AddedOn).ToList();
        }
        public IEnumerable<User> GetActiveDoctors()
        {
            return _context.Users.Where(u => u.Role == "Doctor" && u.IsActive == true).OrderBy(u => u.Name).ToList();
        }
        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Mobile == username);
        }
        public IEnumerable<object> GetAppointmentsForUser(string mobile)
        {
            var query = from a in _context.Appointments
                        join b in _context.BookingSlots
                        on a.BookingSlotID equals b.ID
                        join u in _context.Users
                        on b.Mobile equals u.Mobile
                        where a.Mobile == mobile
                        select new
                        {
                            TokenNo = a.TokenNo,
                            DoctorName = u.Name,
                            DoctorAddress = u.Address,
                            AppointmentDate = a.AppointmentDate,
                            BookingSlot = b.FromTo
                        };

            return query.OrderByDescending(q => q.AppointmentDate).ToList();
        }

        public IEnumerable<object> GetAppointmentsForDoctor(string mobile)
        {
            var query = from a in _context.Appointments
                        join b in _context.BookingSlots
                        on a.BookingSlotID equals b.ID
                        join u in _context.Users
                        on b.Mobile equals u.Mobile
                        where b.Mobile == mobile
                        select new
                        {
                            TokenNo = a.TokenNo,
                            AppointmentDate = a.AppointmentDate,
                            BookingSlot = b.FromTo
                        };

            return query.OrderByDescending(q => q.AppointmentDate).ToList();
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

        public ApiResponse ActivateUser(string mobile)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Mobile == mobile);
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        return new ApiResponse
                        {
                            Added = false,
                            Message = "User active already."
                        };
                    }

                    user.IsActive = true;
                    _context.SaveChanges();
                    return new ApiResponse
                    {
                        Added = true,
                        Message = "User activated successfully."
                    };
                }
                return new ApiResponse
                {
                    Added = false,
                    Message = "User not found. Please try again..."
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

        public ApiResponse DeactivateUser(string mobile)
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
                            Message = "User deactivated already"
                        };
                    }

                    user.IsActive = false;
                    _context.SaveChanges();
                    return new ApiResponse
                    {
                        Added = true,
                        Message = "User deactivated successfully."
                    };
                }
                return new ApiResponse
                {
                    Added = false,
                    Message = "User not found. Please try again..."
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

        public ApiResponse ChangePassword(string mobile, string oldPassword, string newPassword)
        {
            try
            {
                if(oldPassword == newPassword)
                {
                    return new ApiResponse
                    {
                        Added = false,
                        Message = "Old and New Passwords can't be same."
                    };
                }
                var user = _context.Users.Where(u => u.Mobile == mobile && u.Password == oldPassword).SingleOrDefault();
                if (user != null)
                {
                    user.Password = newPassword;
                    _context.SaveChanges();
                    return new ApiResponse
                    {
                        Added = true,
                        Message = "Password changed successfully. Please login again to access your account."
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        Added = false,
                        Message = "Please enter correct Old Password and try again..."
                    };
                }
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
        public bool VerifyRecaptcha(string token, string secretKey)
        {
            HttpClient client = new HttpClient();
            string res = client.GetStringAsync("https://www.google.com/recaptcha/api/siteverify?secret=" + secretKey + "&response=" + token).Result;
            dynamic resultObj = JValue.Parse(res);
            if (resultObj.success != null && resultObj.success != true)
            {
                return false;
            }

            return true;
        }

        public ApiResponse DeleteDoctor(string mobile)
        {
            try
            {
                var doctor = _context.Users.Where(u => u.Mobile == mobile).FirstOrDefault();
                if(doctor != null)
                {
                    _context.Users.Remove(doctor);
                    _context.SaveChanges();
                    return new ApiResponse
                    {
                        Added = true,
                        Message = "Doctor deleted successfully."
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
    }
}
