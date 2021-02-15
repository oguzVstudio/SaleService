namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductTable",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductCode = c.String(maxLength: 50),
                        ProductName = c.String(),
                        Description = c.String(),
                        Barcode = c.String(maxLength: 20),
                        IsDeleted = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 20),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ProductCode, unique: true);
            
            CreateTable(
                "dbo.SaleDetailTable",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LineNo = c.Int(nullable: false),
                        ProductId = c.Long(nullable: false),
                        SalesPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CampaignId = c.Long(nullable: false),
                        SaleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTable", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SalesTable", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SaleId);
            
            CreateTable(
                "dbo.SalesTable",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SalesPrice = c.Double(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        Quantity = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerTable", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "secure.UserTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleDetailTable", "SaleId", "dbo.SalesTable");
            DropForeignKey("dbo.SalesTable", "CustomerId", "dbo.CustomerTable");
            DropForeignKey("dbo.SaleDetailTable", "ProductId", "dbo.ProductTable");
            DropIndex("dbo.SalesTable", new[] { "CustomerId" });
            DropIndex("dbo.SaleDetailTable", new[] { "SaleId" });
            DropIndex("dbo.SaleDetailTable", new[] { "ProductId" });
            DropIndex("dbo.ProductTable", new[] { "ProductCode" });
            DropTable("secure.UserTable");
            DropTable("dbo.SalesTable");
            DropTable("dbo.SaleDetailTable");
            DropTable("dbo.ProductTable");
            DropTable("dbo.CustomerTable");
        }
    }
}
