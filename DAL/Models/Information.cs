using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Information
    {
        [Key]
        public long ID { get; set; }
        public string Vaccination { get; set; }
        public string FertilityManagement { get; set; }
        public string HygenicMilk { get; set; }
    }
}
