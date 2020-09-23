using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookingSlotDAL
    {
        VCDbContext _context = new VCDbContext();

        public ApiResponse AddBookingSlot(BookingSlot bookingSlot)
        {
            try
            {
                _context.BookingSlots.Add(bookingSlot);
                _context.SaveChanges();
                return new ApiResponse
                {
                    Added = true,
                    Message = "Booking Slot added successfully."
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

        public IEnumerable<BookingSlot> GetBookingSlotsForDoctor(string mobile)
        {
            return _context.BookingSlots.Where(b => b.Mobile == mobile).OrderBy(b => b.Day).ToList();
        }

        public ApiResponse DeleteBookingSlot(long id)
        {
            try
            {
                var bookingSlot = _context.BookingSlots.FirstOrDefault(b => b.ID == id);
                if(bookingSlot != null)
                {
                    _context.BookingSlots.Remove(bookingSlot);
                    _context.SaveChanges();
                    return new ApiResponse
                    {
                        Added = false,
                        Message = "Booking Slot deleted successfully."
                    };
                }

                return new ApiResponse
                {
                    Added = false,
                    Message = "Booking Slot not found."
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
