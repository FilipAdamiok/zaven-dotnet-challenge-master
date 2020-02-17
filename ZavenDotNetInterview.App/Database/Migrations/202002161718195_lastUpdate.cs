namespace ZavenDotNetInterview.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "LastUpdatedDate", c => c.DateTime());
            DropColumn("dbo.Jobs", "LastUpdatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "LastUpdatedAt", c => c.DateTime());
            DropColumn("dbo.Jobs", "LastUpdatedDate");
        }
    }
}
