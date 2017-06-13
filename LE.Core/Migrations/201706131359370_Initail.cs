namespace LE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initail : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Departments", "DepartNo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Departments", "DepartNo");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Departments", "DepartNo", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Departments", "DepartNo");
        }
    }
}
