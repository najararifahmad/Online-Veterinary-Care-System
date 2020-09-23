using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AppointmentSetting
    {
        [Key]
        public long ID { get; set; }
        public string Mobile { get; set; }
        [ForeignKey("Mobile")]
        public User User { get; set; }
        public long BookingSlotID { get; set; }
        [ForeignKey("BookingSlotID")]
        public BookingSlot BookingSlot { get; set; }
        public int AppointmentsCount { get; set; }

    }
}
