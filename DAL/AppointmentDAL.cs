﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppointmentDAL
    {
        VCDbContext _context = new VCDbContext();

        public ApiResponse CheckAppointment(long bookingSlotId, DateTime bookingDate)
        {
            var bookingSlot = _context.BookingSlots.FirstOrDefault(b => b.ID == bookingSlotId);
            if(bookingSlot == null)
            {
                return new ApiResponse
                {
                    Added = false,
                    Message = "Booking Slot not found."
                };
            }

            var numPatients = bookingSlot.NumPatients;

            var numAppointmentsBooked = _context.Appointments.Where(a => a.AppointmentDate == bookingDate &&
                                                                    a.BookingSlotID == bookingSlotId).Count();

            if(numAppointmentsBooked >= numPatients)
            {
                return new ApiResponse
                {
                    Added = false,
                    Message = "Appointment not available. Please try another booking slot."
                };
            }

            return new ApiResponse
            {
                Added = true,
                Message = "Appointment available with token number: " + (numAppointmentsBooked + 1)
            };
        }

        //public ApiResponse BookAppointment(long bookingSlotId, DateTime bookingDate, 
        //                                   string mobile, string name, string address,
        //                                   string contactNo, string petName)
        //{

        //}
    }
}
