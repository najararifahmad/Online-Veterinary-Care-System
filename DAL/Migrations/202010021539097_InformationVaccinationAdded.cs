namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InformationVaccinationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Vaccination = c.String(),
                        InformationDissemination = c.String(),
                        FertilityManagement = c.String(),
                        HygenicMilk = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Information");
        }
    }
}
