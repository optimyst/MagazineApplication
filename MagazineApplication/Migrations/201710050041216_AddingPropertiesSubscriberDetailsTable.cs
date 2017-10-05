namespace MagazineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPropertiesSubscriberDetailsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscribers", "Address", c => c.String());
            AddColumn("dbo.Subscribers", "Email", c => c.String());
            AddColumn("dbo.Subscribers", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscribers", "Phone");
            DropColumn("dbo.Subscribers", "Email");
            DropColumn("dbo.Subscribers", "Address");
        }
    }
}
