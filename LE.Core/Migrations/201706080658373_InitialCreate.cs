namespace LE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orgnizations",
                c => new
                    {
                        OrgNo = c.Int(nullable: false, identity: true),
                        OrgName = c.String(nullable: false, maxLength: 50),
                        OrgDuty = c.String(),
                        OrgDes = c.String(),
                        OrgFlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrgNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orgnizations");
        }
    }
}
