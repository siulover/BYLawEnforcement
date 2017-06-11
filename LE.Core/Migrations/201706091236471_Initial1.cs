namespace LE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Officials",
                c => new
                    {
                        OffNo = c.String(nullable: false, maxLength: 128),
                        Offname = c.String(),
                        DepNo = c.String(),
                        MobileNo = c.String(),
                        OffPwd = c.String(),
                        LawForcementNo = c.String(),
                        OfficialFlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OffNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Officials");
        }
    }
}
