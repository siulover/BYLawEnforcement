using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace LE.Core
{
    public class LawEnforcementContext:DbContext
    {

        //继承DbContext，如果DbContext在Web项目中，其会自动关联与其同名的连接字符串。
        //在这里通过base（），来连接Webconfig中ConnectionString名字为DefaultConnection的连接字符串。
        //由于重写了base，因此需要把自动创建数据库的方法重新执行。
        public LawEnforcementContext() : base("DefaultConnection")
        {
            Database.SetInitializer<LawEnforcementContext>(new CreateDatabaseIfNotExists<LawEnforcementContext>());
        }

        public System.Data.Entity.DbSet<Model.Orgnizations> Orgnizations { get; set; }
        public System.Data.Entity.DbSet<Model.Departments> Departments { get; set; }
        public System.Data.Entity.DbSet<Model.Officials> Officials { get; set; }
        public System.Data.Entity.DbSet<Model.CaseCategory> CaseCategory { get; set; }
        public System.Data.Entity.DbSet<Model.CateMeta> CateMeta { get; set; }
        public System.Data.Entity.DbSet<Model.Case> Case { get; set; }
        public System.Data.Entity.DbSet<Model.CaseTrace> CaseTrace { get; set; }

    }
}
