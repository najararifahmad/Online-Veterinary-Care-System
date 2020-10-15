namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "HospitalAddress", c => c.String());
            AddColumn("dbo.Users", "OfficialMail", c => c.String());
            AddColumn("dbo.Users", "OfficialFax", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "OfficialFax");
            DropColumn("dbo.Users", "OfficialMail");
            DropColumn("dbo.Users", "HospitalAddress");
        }
    }
}
