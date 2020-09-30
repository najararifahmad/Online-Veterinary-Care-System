namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserVerificationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IdentityCardImagePath", c => c.String());
            AddColumn("dbo.Users", "AadharCardImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AadharCardImagePath");
            DropColumn("dbo.Users", "IdentityCardImagePath");
        }
    }
}
