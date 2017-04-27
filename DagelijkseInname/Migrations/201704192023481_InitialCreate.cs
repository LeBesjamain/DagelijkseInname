namespace DagelijkseInname.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DagboekEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        GeconsumeerdInGram = c.Decimal(nullable: false, precision: 18, scale: 4),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Foto = c.Binary(),
                        Naam = c.String(),
                        HoeveelheidVetPerGram = c.Decimal(nullable: false, precision: 18, scale: 4),
                        HoeveelheidEiwitPerGram = c.Decimal(nullable: false, precision: 18, scale: 4),
                        HoeveelheidKoolhydratenPerGram = c.Decimal(nullable: false, precision: 18, scale: 4),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DagboekEntries", "ProductId", "dbo.Products");
            DropIndex("dbo.DagboekEntries", new[] { "ProductId" });
            DropTable("dbo.Products");
            DropTable("dbo.DagboekEntries");
        }
    }
}
