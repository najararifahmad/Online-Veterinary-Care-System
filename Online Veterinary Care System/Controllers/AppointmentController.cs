using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Online_Veterinary_Care_System.Controllers
{
    public class AppointmentController : ApiController
    {
        AppointmentBAL _bal = new AppointmentBAL();

        [HttpGet]
        [Route("api/Appointment/CheckAppointment")]
        public IHttpActionResult CheckAppointment(long bookingSlotId, string bookingDate)
        {
            return Ok(_bal.CheckAppointment(bookingSlotId, DateTime.ParseExact(bookingDate, "MM/dd/yyyy", null)));
        }

        [HttpPost]
        [Route("api/Appointment/BookAppointment")]
        public IHttpActionResult BookAppointment(long bookingSlotId, string bookingDate,
                                           string mobile, string name, string address,
                                           string contactNo, string petName)
        {
            return Ok(_bal.BookAppointment(bookingSlotId, DateTime.ParseExact(bookingDate, "MM/dd/yyyy", null),
                mobile, name, address, contactNo, petName));
        }
    }
}