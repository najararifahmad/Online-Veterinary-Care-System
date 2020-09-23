using BAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Online_Veterinary_Care_System.Controllers
{
    public class BookingSlotController : ApiController
    {
        BookingSlotBAL _bal = new BookingSlotBAL();

        public IHttpActionResult GetBookingSlotsForDoctor(string mobile)
        {
            return Ok(_bal.GetBookingSlotsForDoctor(mobile));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] BookingSlot bookingSlot)
        {
            return Ok(_bal.AddBookingSlot(bookingSlot));
        }

        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            return Ok(_bal.DeleteBookingSlot(id));
        }
    }
}