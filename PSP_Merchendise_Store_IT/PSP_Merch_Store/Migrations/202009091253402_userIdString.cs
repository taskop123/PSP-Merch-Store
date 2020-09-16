namespace PSP_Merch_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userIdString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShoppingCarts", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShoppingCarts", "UserId", c => c.Int(nullable: false));
        }
    }
}
