namespace ZavenDotNetInterview.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobsCreationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "CreationDate");
        }
    }
}
