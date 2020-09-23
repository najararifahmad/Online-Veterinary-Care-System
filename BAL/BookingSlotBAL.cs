using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BookingSlotBAL
    {
        BookingSlotDAL _dal = new BookingSlotDAL();
        public ApiResponse AddBookingSlot(BookingSlot bookingSlot)
        {
            return _dal.AddBookingSlot(bookingSlot);
        }

        public IEnumerable<BookingSlot> GetBookingSlotsForDoctor(string mobile)
        {
            return _dal.GetBookingSlotsForDoctor(mobile);
        }

        public ApiResponse DeleteBookingSlot(long id)
        {
            return _dal.DeleteBookingSlot(id);
        }
    }
}
