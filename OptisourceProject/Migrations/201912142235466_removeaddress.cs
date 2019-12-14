namespace OptisourceProject.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeaddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Registers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registers", "Address", c => c.String());
        }
    }
}
