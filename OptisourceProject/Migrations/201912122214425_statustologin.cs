namespace OptisourceProject.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statustologin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "Status");
        }
    }
}
