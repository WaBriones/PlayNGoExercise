namespace PlayNGoExercice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTableReferences : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CofeeMenu", newName: "CoffeeMenu");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CoffeeMenu", newName: "CofeeMenu");
        }
    }
}
