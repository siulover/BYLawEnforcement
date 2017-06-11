namespace LE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaseCategories",
                c => new
                    {
                        CategoryNo = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryFlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CaseCategories");
        }
    }
}
