namespace PSP_Merch_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartId);
            
            AddColumn("dbo.BottomClothes", "ShoppingCart_ShoppingCartId", c => c.Int());
            AddColumn("dbo.Hats", "ShoppingCart_ShoppingCartId", c => c.Int());
            AddColumn("dbo.TopClothes", "ShoppingCart_ShoppingCartId", c => c.Int());
            CreateIndex("dbo.BottomClothes", "ShoppingCart_ShoppingCartId");
            CreateIndex("dbo.Hats", "ShoppingCart_ShoppingCartId");
            CreateIndex("dbo.TopClothes", "ShoppingCart_ShoppingCartId");
            AddForeignKey("dbo.BottomClothes", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");
            AddForeignKey("dbo.Hats", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");
            AddForeignKey("dbo.TopClothes", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TopClothes", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Hats", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.BottomClothes", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.TopClothes", new[] { "ShoppingCart_ShoppingCartId" });
            DropIndex("dbo.Hats", new[] { "ShoppingCart_ShoppingCartId" });
            DropIndex("dbo.BottomClothes", new[] { "ShoppingCart_ShoppingCartId" });
            DropColumn("dbo.TopClothes", "ShoppingCart_ShoppingCartId");
            DropColumn("dbo.Hats", "ShoppingCart_ShoppingCartId");
            DropColumn("dbo.BottomClothes", "ShoppingCart_ShoppingCartId");
            DropTable("dbo.ShoppingCarts");
        }
    }
}
