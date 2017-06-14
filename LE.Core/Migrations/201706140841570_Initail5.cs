namespace LE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initail5 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Departments", "OrgNo");
            AddForeignKey("dbo.Departments", "OrgNo", "dbo.Orgnizations", "OrgNo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "OrgNo", "dbo.Orgnizations");
            DropIndex("dbo.Departments", new[] { "OrgNo" });
        }
    }
}
