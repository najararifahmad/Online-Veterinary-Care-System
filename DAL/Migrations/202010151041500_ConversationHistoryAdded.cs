namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConversationHistoryAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConversationHistories",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SenderMobile = c.String(),
                        ReceiverMobile = c.String(),
                        Message = c.String(),
                        AddedOn = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConversationHistories");
        }
    }
}
