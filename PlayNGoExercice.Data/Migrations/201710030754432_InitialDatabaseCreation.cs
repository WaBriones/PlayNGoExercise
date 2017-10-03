namespace PlayNGoExercice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        OfficeId = c.Int(nullable: false, identity: true),
                        OfficeName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.OfficeId);
            
            CreateTable(
                "dbo.Pantry",
                c => new
                    {
                        PantryId = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        PantryName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.PantryId)
                .ForeignKey("dbo.Office", t => t.OfficeId, cascadeDelete: true)
                .Index(t => t.OfficeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pantry", "OfficeId", "dbo.Office");
            DropIndex("dbo.Pantry", new[] { "OfficeId" });
            DropTable("dbo.Pantry");
            DropTable("dbo.Office");
        }
    }
}
