namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConversationHistoryChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConversationHistories", "AddedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConversationHistories", "AddedOn", c => c.String());
        }
    }
}
