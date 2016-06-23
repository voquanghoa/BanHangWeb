namespace BanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authentications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionCode = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginName = c.String(),
                        Password = c.String(),
                        JobTitle = c.String(),
                        Role = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        Id = c.Int(nullable: false, identity: true),
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
                        Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerGroups", t => t.Group_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.CustomerGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        Customer_Id = c.Int(),
                        Employee_Id = c.Int(),
                        Production_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Productions", t => t.Production_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Production_Id);
            
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        Brand_Id = c.Int(),
                        Category_Id = c.Int(),
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
                        Id = c.Int(nullable: false, identity: true),
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
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                        Employee_Id = c.Int(),
                        Production_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Productions", t => t.Production_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Production_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Production_Id", "dbo.Productions");
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "Production_Id", "dbo.Productions");
            DropForeignKey("dbo.Productions", "Category_Id", "dbo.CategoryProducts");
            DropForeignKey("dbo.Productions", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.Invoices", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Invoices", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Group_Id", "dbo.CustomerGroups");
            DropForeignKey("dbo.Authentications", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Orders", new[] { "Production_Id" });
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Productions", new[] { "Category_Id" });
            DropIndex("dbo.Productions", new[] { "Brand_Id" });
            DropIndex("dbo.Invoices", new[] { "Production_Id" });
            DropIndex("dbo.Invoices", new[] { "Employee_Id" });
            DropIndex("dbo.Invoices", new[] { "Customer_Id" });
            DropIndex("dbo.Customers", new[] { "Group_Id" });
            DropIndex("dbo.Authentications", new[] { "Employee_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.CategoryProducts");
            DropTable("dbo.Productions");
            DropTable("dbo.Invoices");
            DropTable("dbo.CustomerGroups");
            DropTable("dbo.Customers");
            DropTable("dbo.Brands");
            DropTable("dbo.Employees");
            DropTable("dbo.Authentications");
        }
    }
}
