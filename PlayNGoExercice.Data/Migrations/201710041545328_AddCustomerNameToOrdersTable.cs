namespace PlayNGoExercice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerNameToOrdersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerName", c => c.String(maxLength: 300));
            AddColumn("dbo.Orders", "DateOrdered", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DateOrdered");
            DropColumn("dbo.Orders", "CustomerName");
        }
    }
}
