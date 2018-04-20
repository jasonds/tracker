namespace tracker.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Location", c => c.String());
            AddColumn("dbo.Users", "IsBench", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "LastUpdatedUtc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LastUpdatedUtc");
            DropColumn("dbo.Users", "IsBench");
            DropColumn("dbo.Users", "Location");
        }
    }
}
