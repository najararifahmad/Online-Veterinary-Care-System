namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InformationDisseminationAddedDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InformationDisseminations", "AddedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Information", "InformationDissemination");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Information", "InformationDissemination", c => c.String());
            AlterColumn("dbo.InformationDisseminations", "AddedOn", c => c.String());
        }
    }
}
