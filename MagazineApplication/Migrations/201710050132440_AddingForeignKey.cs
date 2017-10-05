namespace MagazineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscribers", "SubscriberDetailId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subscribers", "SubscriberDetailId");
            AddForeignKey("dbo.Subscribers", "SubscriberDetailId", "dbo.SubscriberDetails", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscribers", "SubscriberDetailId", "dbo.SubscriberDetails");
            DropIndex("dbo.Subscribers", new[] { "SubscriberDetailId" });
            DropColumn("dbo.Subscribers", "SubscriberDetailId");
        }
    }
}
