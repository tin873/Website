namespace cozaStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cozaStoreDbV1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "StatusId", "dbo.Status");
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Comment", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", "CouponCode", "dbo.Coupon");
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropForeignKey("dbo.User", "RoleID", "dbo.Role");
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropIndex("dbo.Order", new[] { "StatusId" });
            DropPrimaryKey("dbo.OrderDetail");
            CreateTable(
                "dbo.ProductDetail",
                c => new
                    {
                        ProductDetailId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.String(maxLength: 15),
                        Color = c.String(maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductDetailId)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            AddColumn("dbo.OrderDetail", "ProductDetailId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Order", "ShippedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Order", "EndDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddPrimaryKey("dbo.OrderDetail", new[] { "ProductDetailId", "OrderID" });
            CreateIndex("dbo.OrderDetail", "ProductDetailId");
            CreateIndex("dbo.Order", "UserId");
            AddForeignKey("dbo.OrderDetail", "ProductDetailId", "dbo.ProductDetail", "ProductDetailId", cascadeDelete: true);
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Comment", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.Product", "SupplierID", "dbo.Supplier", "SupplierID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.Order", "CouponCode", "dbo.Coupon", "CouponCode", cascadeDelete: true);
            AddForeignKey("dbo.Order", "UserId", "dbo.User", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.User", "RoleID", "dbo.Role", "RoleID", cascadeDelete: true);
            DropColumn("dbo.Product", "Size");
            DropColumn("dbo.Product", "Color");
            DropColumn("dbo.Product", "Quantity");
            DropColumn("dbo.OrderDetail", "ProductID");
            DropColumn("dbo.Order", "StatusId");
            DropTable("dbo.Status");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.StatusId);
            
            AddColumn("dbo.Order", "StatusId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetail", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Color", c => c.String(maxLength: 50));
            AddColumn("dbo.Product", "Size", c => c.String(maxLength: 15));
            DropForeignKey("dbo.User", "RoleID", "dbo.Role");
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.Order", "CouponCode", "dbo.Coupon");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Comment", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.ProductDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "ProductDetailId", "dbo.ProductDetail");
            DropIndex("dbo.Order", new[] { "UserId" });
            DropIndex("dbo.OrderDetail", new[] { "ProductDetailId" });
            DropIndex("dbo.ProductDetail", new[] { "ProductID" });
            DropPrimaryKey("dbo.OrderDetail");
            AlterColumn("dbo.Order", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "ShippedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "CreateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Order", "Status");
            DropColumn("dbo.OrderDetail", "ProductDetailId");
            DropTable("dbo.ProductDetail");
            AddPrimaryKey("dbo.OrderDetail", new[] { "ProductID", "OrderID" });
            CreateIndex("dbo.Order", "StatusId");
            CreateIndex("dbo.Order", "UserID");
            CreateIndex("dbo.OrderDetail", "ProductID");
            AddForeignKey("dbo.User", "RoleID", "dbo.Role", "RoleID");
            AddForeignKey("dbo.Order", "UserID", "dbo.User", "UserID");
            AddForeignKey("dbo.Order", "CouponCode", "dbo.Coupon", "CouponCode");
            AddForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order", "OrderID");
            AddForeignKey("dbo.Product", "SupplierID", "dbo.Supplier", "SupplierID");
            AddForeignKey("dbo.Comment", "ProductID", "dbo.Product", "ProductID");
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "CategoryID");
            AddForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product", "ProductID");
            AddForeignKey("dbo.Order", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
        }
    }
}
