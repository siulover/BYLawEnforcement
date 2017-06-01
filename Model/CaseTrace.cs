using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 案件追踪情况
    /// </summary>
    public class CaseTrace
    {
        int TraceNo { get; set; }
        string CaseNo { get; set; }
        string TraceTitle { get; set; }
        /// <summary>
        ///本次跟踪的内容
        /// </summary>
        string TraceComment { get; set; }
        /// <summary>
        /// 跟踪日期
        /// </summary>
        string TraceDate { get; set; }

        string TraceFile { get; set; }
        /// <summary>
        /// 跟踪过程发出的文件编号
        /// </summary>
        string TraceFileNo { get; set; }

        int TraceFlag { get; set; }

    }
}
