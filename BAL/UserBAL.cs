﻿using DAL;
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

        public IEnumerable<User> GetDoctors()
        {
            return _dal.GetDoctors();
        }
        public IEnumerable<User> GetActiveDoctors()
        {
            return _dal.GetActiveDoctors();
        }
        public User GetUserByUsername(string username)
        {
            return _dal.GetUserByUsername(username);
        }
        public IEnumerable<object> GetAppointmentsForUser(string mobile)
        {
            return _dal.GetAppointmentsForUser(mobile);
        }
        public IEnumerable<object> GetAppointmentsForDoctor(string mobile)
        {
            return _dal.GetAppointmentsForDoctor(mobile);
        }

        public ApiResponse GenerateAdmin(string password)
        {
            return _dal.GenerateAdmin(password);
        }

        public ApiResponse ApproveDoctor(string mobile)
        {
            return _dal.ApproveDoctor(mobile);
        }

        public ApiResponse RejectDoctor(string mobile)
        {
            return _dal.RejectDoctor(mobile);
        }

        public ApiResponse RegisterUser(User user)
        {
            return _dal.RegisterUser(user);
        }
        public ApiResponse SaveDoctorVerificationImages(User user)
        {
            return _dal.SaveDoctorVerificationImages(user);
        }
        public ApiResponse ChangePassword(string mobile, string oldPassword, string newPassword)
        {
            return _dal.ChangePassword(mobile, oldPassword, newPassword);
        }
        public bool VerifyRecaptcha(string token, string secretKey)
        {
            return _dal.VerifyRecaptcha(token, secretKey);
        }
    }
}
