namespace ZavenDotNetInterview.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "LastUpdatedAt", c => c.DateTime());
            AddColumn("dbo.Jobs", "FailureCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "FailureCount");
            DropColumn("dbo.Jobs", "LastUpdatedAt");
        }
    }
}
