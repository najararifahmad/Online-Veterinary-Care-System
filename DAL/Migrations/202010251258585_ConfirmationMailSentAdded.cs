namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfirmationMailSentAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ConfirmationMailSent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ConfirmationMailSent");
        }
    }
}
