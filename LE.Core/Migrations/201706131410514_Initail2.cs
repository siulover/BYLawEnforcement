namespace LE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initail2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DepartName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Departments", "OrgNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "OrgNo", c => c.String());
            AlterColumn("dbo.Departments", "DepartName", c => c.String());
        }
    }
}
