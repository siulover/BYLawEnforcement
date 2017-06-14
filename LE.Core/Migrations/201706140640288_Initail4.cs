namespace LE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initail4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "OrgNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "OrgNo", c => c.String(nullable: false));
        }
    }
}
