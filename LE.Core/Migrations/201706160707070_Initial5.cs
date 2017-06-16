namespace LE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Officials");
            AlterColumn("dbo.Officials", "OffNo", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Officials", "Offname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Officials", "MobileNo", c => c.String(nullable: false));
            AlterColumn("dbo.Officials", "OffPwd", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.Officials", "OffNo");
            CreateIndex("dbo.Officials", "DepNo");
            AddForeignKey("dbo.Officials", "DepNo", "dbo.Departments", "DepartNo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Officials", "DepNo", "dbo.Departments");
            DropIndex("dbo.Officials", new[] { "DepNo" });
            DropPrimaryKey("dbo.Officials");
            AlterColumn("dbo.Officials", "OffPwd", c => c.String());
            AlterColumn("dbo.Officials", "MobileNo", c => c.String());
            AlterColumn("dbo.Officials", "Offname", c => c.String());
            AlterColumn("dbo.Officials", "OffNo", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Officials", "OffNo");
        }
    }
}
