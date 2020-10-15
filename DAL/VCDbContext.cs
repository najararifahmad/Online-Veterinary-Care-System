using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VCDbContext: DbContext
    {
        public VCDbContext() : base("name=ConnectionString")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<BookingSlot> BookingSlots { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<InformationDissemination> InformationDisseminations { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<ConversationHistory> ConversationHistories { get; set; }
    }
}
