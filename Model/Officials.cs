using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    /// <summary>
    /// 工作人员
    /// </summary>
    public class Officials
    {
        /// <summary>
        /// 工作人员编号
        /// </summary>
        [Key]
        public string OffNo { get; set; }

        public string Offname { get; set;}
        public int DepNo { get; set; }

        public string MobileNo { get; set; }

        public string OffPwd { get; set; }
        /// <summary>
        /// 执法证号
        /// </summary>
        public string LawForcementNo { get; set; }
        public int OfficialFlag { get; set; }


    }
}
