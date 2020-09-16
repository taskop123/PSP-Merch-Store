namespace PSP_Merch_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCartModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        CartId = c.String(),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Product_ProductsId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Products", t => t.Product_ProductsId)
                .Index(t => t.Product_ProductsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "Product_ProductsId", "dbo.Products");
            DropIndex("dbo.CartItems", new[] { "Product_ProductsId" });
            DropTable("dbo.CartItems");
        }
    }
}
