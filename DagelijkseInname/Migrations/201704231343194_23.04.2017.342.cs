namespace DagelijkseInname.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23042017342 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Kcal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Kcal");
        }
    }
}
