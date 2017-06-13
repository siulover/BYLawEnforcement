namespace LE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initail1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Officials", "DepNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Officials", "DepNo", c => c.String());
        }
    }
}
