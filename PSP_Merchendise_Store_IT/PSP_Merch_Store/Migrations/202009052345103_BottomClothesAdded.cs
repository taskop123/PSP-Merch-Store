namespace PSP_Merch_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BottomClothesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BottomClothes",
                c => new
                    {
                        BottomClothesId = c.Int(nullable: false, identity: true),
                        NameOfProduct = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                        ImagePath = c.String(nullable: false),
                        Size = c.String(nullable: false),
                        Manufacturer = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.BottomClothesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BottomClothes");
        }
    }
}
