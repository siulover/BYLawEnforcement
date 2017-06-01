using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYLawEnforcement.Areas.BaseManage.Models
{
    /// <summary>
    /// 案件标记，社保投诉案件、监察农民工工资投诉案件等
    /// </summary>
    public class CateMeta
    {

        public int CateMetaNo { get; set; }

        public string CateMetaName { get; set; }

        public int CateMetaFlag { get; set; }
    }
}
