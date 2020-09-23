namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToTimeDeletedInBookingSlot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingSlots", "FromTo", c => c.String());
            DropColumn("dbo.BookingSlots", "FromTime");
            DropColumn("dbo.BookingSlots", "ToTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingSlots", "ToTime", c => c.String());
            AddColumn("dbo.BookingSlots", "FromTime", c => c.String());
            DropColumn("dbo.BookingSlots", "FromTo");
        }
    }
}
