namespace PSP_Merch_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageFileToModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TopClothes", "ImagePath", c => c.String(nullable: false));
            DropColumn("dbo.TopClothes", "ImageURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TopClothes", "ImageURL", c => c.String(nullable: false));
            DropColumn("dbo.TopClothes", "ImagePath");
        }
    }
}
