namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentSettingRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppointmentSettings", "BookingSlotID", "dbo.BookingSlots");
            DropForeignKey("dbo.AppointmentSettings", "Mobile", "dbo.Users");
            DropIndex("dbo.AppointmentSettings", new[] { "Mobile" });
            DropIndex("dbo.AppointmentSettings", new[] { "BookingSlotID" });
            DropTable("dbo.AppointmentSettings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AppointmentSettings",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Mobile = c.String(maxLength: 20),
                        BookingSlotID = c.Long(nullable: false),
                        AppointmentsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.AppointmentSettings", "BookingSlotID");
            CreateIndex("dbo.AppointmentSettings", "Mobile");
            AddForeignKey("dbo.AppointmentSettings", "Mobile", "dbo.Users", "Mobile");
            AddForeignKey("dbo.AppointmentSettings", "BookingSlotID", "dbo.BookingSlots", "ID", cascadeDelete: true);
        }
    }
}
