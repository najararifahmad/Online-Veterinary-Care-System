using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class InformationDissemination
    {
        [Key]
        public int ID { get; set; }
        public string InformationText { get; set; }
        public string FilePath { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
