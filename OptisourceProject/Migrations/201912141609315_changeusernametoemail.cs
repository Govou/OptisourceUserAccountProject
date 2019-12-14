namespace OptisourceProject.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeusernametoemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Logins", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Logins", "Email");
        }
    }
}
