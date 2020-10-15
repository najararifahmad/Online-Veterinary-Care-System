using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Conversation
    {
        public long ID { get; set; }
        public string SenderMobile { get; set; }
        public string ReceiverMobile { get; set; }
        public string Message { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
