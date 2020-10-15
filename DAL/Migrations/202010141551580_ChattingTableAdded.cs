namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChattingTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SenderMobile = c.String(),
                        ReceiverMobile = c.String(),
                        Message = c.String(),
                        FilePath = c.String(),
                        Status = c.String(),
                        AddedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Conversations");
        }
    }
}
