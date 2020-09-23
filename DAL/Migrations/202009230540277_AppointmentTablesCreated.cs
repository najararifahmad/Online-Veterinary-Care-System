namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentTablesCreated : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Mobile = c.String(maxLength: 20),
                        UserMobile = c.String(maxLength: 20),
                        AppointmentDate = c.DateTime(nullable: false),
                        BookingSlotID = c.Long(nullable: false),
                        TokenNo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookingSlots", t => t.BookingSlotID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Mobile)
                .ForeignKey("dbo.Users", t => t.UserMobile)
                .Index(t => t.Mobile)
                .Index(t => t.UserMobile)
                .Index(t => t.BookingSlotID);
            
            CreateTable(
                "dbo.BookingSlots",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Mobile = c.String(maxLength: 20),
                        Day = c.String(),
                        FromTime = c.String(),
                        ToTime = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Mobile)
                .Index(t => t.Mobile);
            
            CreateTable(
                "dbo.AppointmentSettings",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Mobile = c.String(maxLength: 20),
                        BookingSlotID = c.Long(nullable: false),
                        AppointmentsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookingSlots", t => t.BookingSlotID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Mobile)
                .Index(t => t.Mobile)
                .Index(t => t.BookingSlotID);
            
            AlterColumn("dbo.Users", "Mobile", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.Users", "Mobile");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentSettings", "Mobile", "dbo.Users");
            DropForeignKey("dbo.AppointmentSettings", "BookingSlotID", "dbo.BookingSlots");
            DropForeignKey("dbo.Appointments", "UserMobile", "dbo.Users");
            DropForeignKey("dbo.Appointments", "Mobile", "dbo.Users");
            DropForeignKey("dbo.Appointments", "BookingSlotID", "dbo.BookingSlots");
            DropForeignKey("dbo.BookingSlots", "Mobile", "dbo.Users");
            DropIndex("dbo.AppointmentSettings", new[] { "BookingSlotID" });
            DropIndex("dbo.AppointmentSettings", new[] { "Mobile" });
            DropIndex("dbo.BookingSlots", new[] { "Mobile" });
            DropIndex("dbo.Appointments", new[] { "BookingSlotID" });
            DropIndex("dbo.Appointments", new[] { "UserMobile" });
            DropIndex("dbo.Appointments", new[] { "Mobile" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Mobile", c => c.String(maxLength: 20));
            DropTable("dbo.AppointmentSettings");
            DropTable("dbo.BookingSlots");
            DropTable("dbo.Appointments");
            AddPrimaryKey("dbo.Users", "ID");
        }
    }
}
