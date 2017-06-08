namespace LE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartNo = c.String(nullable: false, maxLength: 128),
                        DepartName = c.String(),
                        OrgNo = c.String(),
                        DepartmentFlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Departments");
        }
    }
}
