namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConversationStuffCompleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConversationHistories", "Sender", c => c.String());
            AddColumn("dbo.ConversationHistories", "Receiver", c => c.String());
            AddColumn("dbo.Conversations", "Sender", c => c.String());
            AddColumn("dbo.Conversations", "Receiver", c => c.String());
            DropColumn("dbo.ConversationHistories", "SenderMobile");
            DropColumn("dbo.ConversationHistories", "ReceiverMobile");
            DropColumn("dbo.Conversations", "SenderMobile");
            DropColumn("dbo.Conversations", "ReceiverMobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Conversations", "ReceiverMobile", c => c.String());
            AddColumn("dbo.Conversations", "SenderMobile", c => c.String());
            AddColumn("dbo.ConversationHistories", "ReceiverMobile", c => c.String());
            AddColumn("dbo.ConversationHistories", "SenderMobile", c => c.String());
            DropColumn("dbo.Conversations", "Receiver");
            DropColumn("dbo.Conversations", "Sender");
            DropColumn("dbo.ConversationHistories", "Receiver");
            DropColumn("dbo.ConversationHistories", "Sender");
        }
    }
}
