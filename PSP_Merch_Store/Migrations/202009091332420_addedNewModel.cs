namespace PSP_Merch_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNewModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BottomClothes", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Hats", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.TopClothes", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.BottomClothes", new[] { "ShoppingCart_ShoppingCartId" });
            DropIndex("dbo.Hats", new[] { "ShoppingCart_ShoppingCartId" });
            DropIndex("dbo.TopClothes", new[] { "ShoppingCart_ShoppingCartId" });
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductsId = c.Int(nullable: false, identity: true),
                        NameOfProduct = c.String(nullable: false),
                        ProductType = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                        ImagePath = c.String(nullable: false),
                        Size = c.String(nullable: false),
                        Manufacturer = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProductsId);
            
            DropColumn("dbo.BottomClothes", "ShoppingCart_ShoppingCartId");
            DropColumn("dbo.Hats", "ShoppingCart_ShoppingCartId");
            DropColumn("dbo.TopClothes", "ShoppingCart_ShoppingCartId");
            //DropTable("dbo.ShoppingCarts");
        }
        
        public override void Down()
        {
            /*CreateTable(
                "dbo.ShoppingCarts",
                c => new
                {
                    ShoppingCartId = c.Int(nullable: false, identity: true),
                    UserId = c.String(),
                })
                .PrimaryKey(t => t.ShoppingCartId);

            AddColumn("dbo.TopClothes", "ShoppingCart_ShoppingCartId", c => c.Int());
            AddColumn("dbo.Hats", "ShoppingCart_ShoppingCartId", c => c.Int());
            AddColumn("dbo.BottomClothes", "ShoppingCart_ShoppingCartId", c => c.Int());
            DropTable("dbo.Products");
            CreateIndex("dbo.TopClothes", "ShoppingCart_ShoppingCartId");
            CreateIndex("dbo.Hats", "ShoppingCart_ShoppingCartId");
            CreateIndex("dbo.BottomClothes", "ShoppingCart_ShoppingCartId");
            AddForeignKey("dbo.TopClothes", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");
            AddForeignKey("dbo.Hats", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");
            AddForeignKey("dbo.BottomClothes", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");*/
        }
    }
}
