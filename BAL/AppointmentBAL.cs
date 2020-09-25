using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class AppointmentBAL
    {
        AppointmentDAL _dal = new AppointmentDAL();

        public ApiResponse CheckAppointment(long bookingSlotId, DateTime bookingDate)
        {
            return _dal.CheckAppointment(bookingSlotId, bookingDate);
        }

        public ApiResponse BookAppointment(long bookingSlotId, DateTime bookingDate,
                                           string mobile, string name, string address,
                                           string contactNo, string petName)
        {
            return _dal.BookAppointment(bookingSlotId, bookingDate, mobile,
                                        name, address, contactNo, petName);
        }
    }
}
