namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MobileRemovedFromAppointment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "UserMobile", "dbo.Users");
            DropIndex("dbo.Appointments", new[] { "UserMobile" });
            DropColumn("dbo.Appointments", "UserMobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "UserMobile", c => c.String(maxLength: 20));
            CreateIndex("dbo.Appointments", "UserMobile");
            AddForeignKey("dbo.Appointments", "UserMobile", "dbo.Users", "Mobile");
        }
    }
}
