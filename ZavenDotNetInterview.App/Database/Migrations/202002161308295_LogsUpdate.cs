namespace ZavenDotNetInterview.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "StartDateOfJobProcess", c => c.DateTime());
            AddColumn("dbo.Logs", "CreationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Jobs", "DoAfter");
            DropColumn("dbo.Logs", "CreatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "DoAfter", c => c.DateTime());
            DropColumn("dbo.Logs", "CreationDate");
            DropColumn("dbo.Jobs", "StartDateOfJobProcess");
        }
    }
}
