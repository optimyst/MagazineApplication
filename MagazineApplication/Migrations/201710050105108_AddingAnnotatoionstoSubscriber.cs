namespace MagazineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAnnotatoionstoSubscriber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subscribers", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Subscribers", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Subscribers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Subscribers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscribers", "Email", c => c.String());
            AlterColumn("dbo.Subscribers", "Address", c => c.String());
            AlterColumn("dbo.Subscribers", "Description", c => c.String());
            AlterColumn("dbo.Subscribers", "Name", c => c.String());
        }
    }
}
