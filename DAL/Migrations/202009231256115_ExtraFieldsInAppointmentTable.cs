namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraFieldsInAppointmentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Name", c => c.String());
            AddColumn("dbo.Appointments", "Address", c => c.String());
            AddColumn("dbo.Appointments", "ContactNo", c => c.String());
            AddColumn("dbo.Appointments", "PetName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "PetName");
            DropColumn("dbo.Appointments", "ContactNo");
            DropColumn("dbo.Appointments", "Address");
            DropColumn("dbo.Appointments", "Name");
        }
    }
}
