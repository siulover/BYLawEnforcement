using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BYLawEnforcement.Areas.BaseManage.Models
{
    /// <summary>
    /// 工作人员
    /// </summary>
    public class Officials
    {
        /// <summary>
        /// 工作人员编号
        /// </summary>
        public string OffNo { get; set; }

        public string Offname { get; set;}
        public string DepNo { get; set; }

        public string MobileNo { get; set; }

        public string OffPwd { get; set; }
        /// <summary>
        /// 执法证号
        /// </summary>
        public string LawForcementNo { get; set; }
        public int OfficialFlag { get; set; }

    }
}
