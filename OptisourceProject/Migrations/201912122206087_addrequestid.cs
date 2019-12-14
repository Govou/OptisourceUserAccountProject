namespace OptisourceProject.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequestid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Audits", "RequestId", c => c.String());
            AddColumn("dbo.Logins", "RequestId", c => c.String());
            AddColumn("dbo.Registers", "RequestId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registers", "RequestId");
            DropColumn("dbo.Logins", "RequestId");
            DropColumn("dbo.Audits", "RequestId");
        }
    }
}
