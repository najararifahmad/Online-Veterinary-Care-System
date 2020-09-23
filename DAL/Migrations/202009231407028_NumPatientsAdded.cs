namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumPatientsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingSlots", "NumPatients", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingSlots", "NumPatients");
        }
    }
}
