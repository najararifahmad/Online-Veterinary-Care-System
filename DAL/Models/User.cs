using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Required]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(20)]
        [Key]
        public string Mobile { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string IdentityCardImagePath { get; set; }
        public string AadharCardImagePath { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
