namespace LE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        CaseNo = c.String(nullable: false, maxLength: 128),
                        CaseName = c.String(),
                        CaseCategory = c.String(),
                        CaseMeta = c.String(),
                        CaseComplainantID = c.String(),
                        CaseComplainantName = c.String(),
                        CaseComplainantMobil = c.String(),
                        CaseComplainantAdr = c.String(),
                        CaseRequest = c.String(),
                        CaseComplaintDate = c.String(),
                        CaseBeComplaintOrg = c.String(),
                        CaseBeComplaintOrgMg = c.String(),
                        CaseBeComplaintOrgMgTel = c.String(),
                        CaseBeComplaintOrgContact = c.String(),
                        CaseBeComplaintOrgContactTel = c.String(),
                        CaseBeComplaintAdr = c.String(),
                        OfficialNo = c.String(),
                        CaseFlag = c.Int(nullable: false),
                        CaseEndReason = c.String(),
                    })
                .PrimaryKey(t => t.CaseNo);
            
            CreateTable(
                "dbo.CaseTraces",
                c => new
                    {
                        TraceNo = c.Int(nullable: false, identity: true),
                        CaseNo = c.String(),
                        TraceTitle = c.String(),
                        TraceComment = c.String(),
                        TraceDate = c.String(),
                        TraceFile = c.String(),
                        TraceFileNo = c.String(),
                        TraceFlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TraceNo);
            
            CreateTable(
                "dbo.CateMetas",
                c => new
                    {
                        CateMetaNo = c.Int(nullable: false, identity: true),
                        CateMetaName = c.String(),
                        CateMetaFlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CateMetaNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CateMetas");
            DropTable("dbo.CaseTraces");
            DropTable("dbo.Cases");
        }
    }
}
