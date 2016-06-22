namespace BanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Gender = c.Int(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Note = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(nullable: false),
                        Group_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerGroups", t => t.Group_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.CustomerGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Note = c.String(),
                        DiscountPercent = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        JobTitle = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DiscountPercent = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        RetailPrice = c.Int(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(nullable: false),
                        Customer_Id = c.Guid(),
                        Employee_Id = c.Guid(),
                        Production_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .ForeignKey("dbo.Productions", t => t.Production_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Production_Id);
            
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RetailPrice = c.Int(nullable: false),
                        WholesalePrice = c.Int(nullable: false),
                        OriginPrice = c.Int(nullable: false),
                        VipPrice = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        Quantity = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(nullable: false),
                        Brand_Id = c.Guid(),
                        Category_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .ForeignKey("dbo.CategoryProducts", t => t.Category_Id)
                .Index(t => t.Brand_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.CategoryProducts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(nullable: false),
                        Customer_Id = c.Guid(),
                        Employee_Id = c.Guid(),
                        Production_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .ForeignKey("dbo.Productions", t => t.Production_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Production_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Production_Id", "dbo.Productions");
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "Production_Id", "dbo.Productions");
            DropForeignKey("dbo.Productions", "Category_Id", "dbo.CategoryProducts");
            DropForeignKey("dbo.Productions", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.Invoices", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Invoices", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Group_Id", "dbo.CustomerGroups");
            DropIndex("dbo.Orders", new[] { "Production_Id" });
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Productions", new[] { "Category_Id" });
            DropIndex("dbo.Productions", new[] { "Brand_Id" });
            DropIndex("dbo.Invoices", new[] { "Production_Id" });
            DropIndex("dbo.Invoices", new[] { "Employee_Id" });
            DropIndex("dbo.Invoices", new[] { "Customer_Id" });
            DropIndex("dbo.Customers", new[] { "Group_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.CategoryProducts");
            DropTable("dbo.Productions");
            DropTable("dbo.Invoices");
            DropTable("dbo.Employee");
            DropTable("dbo.CustomerGroups");
            DropTable("dbo.Customers");
            DropTable("dbo.Brands");
        }
    }
}
