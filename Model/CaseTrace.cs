using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class CaseTrace
    {
        int TraceNo;
        string CaseNo;
        /// <summary>
        ///本次跟踪的内容
        /// </summary>
        string TraceComment;
        /// <summary>
        /// 跟踪日期
        /// </summary>
        string TraceDate;

        /// <summary>
        /// 跟踪过程发出的文件编号
        /// </summary>
        string TraceFileNo;
    }
}
