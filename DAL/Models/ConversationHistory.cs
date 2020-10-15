using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ConversationHistory
    {
        public long ID { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public DateTime AddedOn { get; set; }
        public string Status { get; set; }
    }
}
