using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    /// <summary>
    /// 案件追踪情况
    /// </summary>
    public class CaseTrace
    {
       [Key]
        public int TraceNo { get; set; }
        public string CaseNo { get; set; }
        public string TraceTitle { get; set; }
        /// <summary>
        ///本次跟踪的内容
        /// </summary>
        public string TraceComment { get; set; }
        /// <summary>
        /// 跟踪日期
        /// </summary>
        public string TraceDate { get; set; }

        public string TraceFile { get; set; }
        /// <summary>
        /// 跟踪过程发出的文件编号
        /// </summary>
        public string TraceFileNo { get; set; }

        public int TraceFlag { get; set; }

    }
}
