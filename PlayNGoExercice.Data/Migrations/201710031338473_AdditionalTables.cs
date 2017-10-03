namespace PlayNGoExercice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrinkCost",
                c => new
                    {
                        DrinkCostId = c.Int(nullable: false, identity: true),
                        DrinkId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DrinkCostId)
                .ForeignKey("dbo.CofeeMenu", t => t.DrinkId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredient", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.DrinkId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.CofeeMenu",
                c => new
                    {
                        DrinkId = c.Int(nullable: false, identity: true),
                        DrinkName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.DrinkId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        DrinkId = c.Int(nullable: false),
                        OfficeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.CofeeMenu", t => t.DrinkId, cascadeDelete: true)
                .ForeignKey("dbo.Office", t => t.OfficeId, cascadeDelete: true)
                .Index(t => t.DrinkId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.PantryStock",
                c => new
                    {
                        PantryStockId = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PantryStockId)
                .ForeignKey("dbo.Ingredient", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Office", t => t.OfficeId, cascadeDelete: true)
                .Index(t => t.OfficeId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.IngredientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrinkCost", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.DrinkCost", "DrinkId", "dbo.CofeeMenu");
            DropForeignKey("dbo.Orders", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.PantryStock", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.PantryStock", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.Orders", "DrinkId", "dbo.CofeeMenu");
            DropIndex("dbo.PantryStock", new[] { "IngredientId" });
            DropIndex("dbo.PantryStock", new[] { "OfficeId" });
            DropIndex("dbo.Orders", new[] { "OfficeId" });
            DropIndex("dbo.Orders", new[] { "DrinkId" });
            DropIndex("dbo.DrinkCost", new[] { "IngredientId" });
            DropIndex("dbo.DrinkCost", new[] { "DrinkId" });
            DropTable("dbo.Ingredient");
            DropTable("dbo.PantryStock");
            DropTable("dbo.Orders");
            DropTable("dbo.CofeeMenu");
            DropTable("dbo.DrinkCost");
        }
    }
}
