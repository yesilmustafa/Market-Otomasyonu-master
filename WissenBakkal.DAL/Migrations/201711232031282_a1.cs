namespace WissenBakkal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        DefaultKDV = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.CustomerPayments",
                c => new
                    {
                        CustomerPaymentID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        PaymentDate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerPaymentID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 50),
                        Telephone = c.String(nullable: false),
                        Address = c.String(),
                        Debt = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false),
                        SaleStatus = c.Boolean(nullable: false),
                        PaymentMethod = c.Int(nullable: false),
                        Discount = c.Byte(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.SaleDetails",
                c => new
                    {
                        SaleDetailID = c.Int(nullable: false, identity: true),
                        SaleID = c.Int(nullable: false),
                        ProductBarcode = c.String(maxLength: 128),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        Quantity = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.SaleDetailID)
                .ForeignKey("dbo.Products", t => t.ProductBarcode)
                .ForeignKey("dbo.Sales", t => t.SaleID, cascadeDelete: true)
                .Index(t => t.SaleID)
                .Index(t => t.ProductBarcode);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductBarcode = c.String(nullable: false, maxLength: 128),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        DisContinued = c.Boolean(nullable: false),
                        KDV = c.Int(nullable: false),
                        Picture = c.Binary(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductBarcode)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        Quantity = c.Short(nullable: false),
                        ProductBarcode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductBarcode)
                .Index(t => t.OrderID)
                .Index(t => t.ProductBarcode);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        OrderStatus = c.Boolean(nullable: false),
                        SupplierID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        ContactName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        Telephone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleDetails", "SaleID", "dbo.Sales");
            DropForeignKey("dbo.SaleDetails", "ProductBarcode", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "ProductBarcode", "dbo.Products");
            DropForeignKey("dbo.Orders", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CustomerPayments", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "SupplierID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductBarcode" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.SaleDetails", new[] { "ProductBarcode" });
            DropIndex("dbo.SaleDetails", new[] { "SaleID" });
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            DropIndex("dbo.CustomerPayments", new[] { "CustomerID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.SaleDetails");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerPayments");
            DropTable("dbo.Categories");
        }
    }
}
