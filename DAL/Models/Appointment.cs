using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Appointment
    {
        [Key]
        public long ID { get; set; }
        public string Mobile { get; set; }
        [ForeignKey("Mobile")]
        public User User { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AppointmentDate { get; set; }
        public long BookingSlotID { get; set; }
        [ForeignKey("BookingSlotID")]
        public BookingSlot BookingSlot { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string PetName { get; set; }
        public long TokenNo { get; set; }
    }
}
