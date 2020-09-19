using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Notification
    {
        public Guid ID { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationText { get; set; }
        public string Link { get; set; }
        public string Username { get; set; }
        public bool Read { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
