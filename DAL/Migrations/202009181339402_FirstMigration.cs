namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        Email = c.String(maxLength: 255),
                        Mobile = c.String(maxLength: 20),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        AddedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
