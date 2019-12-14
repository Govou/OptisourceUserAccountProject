namespace OptisourceProject.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequiredannotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Logins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Registers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Registers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Registers", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Registers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Registers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registers", "Password", c => c.String());
            AlterColumn("dbo.Registers", "Email", c => c.String());
            AlterColumn("dbo.Registers", "UserName", c => c.String());
            AlterColumn("dbo.Registers", "LastName", c => c.String());
            AlterColumn("dbo.Registers", "FirstName", c => c.String());
            AlterColumn("dbo.Logins", "Password", c => c.String());
            AlterColumn("dbo.Logins", "UserName", c => c.String());
        }
    }
}
