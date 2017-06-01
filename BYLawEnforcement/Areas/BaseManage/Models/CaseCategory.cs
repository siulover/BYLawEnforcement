using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYLawEnforcement.Areas.BaseManage.Models
{
    /// <summary>
    /// 案件类别， 违法投诉、欠费催缴、专项审计、信访、其他等案件的分类
    /// </summary>
    public class CaseCategory
    {
        int CategoryNo { get; set; }
        string CategoryName { get; set; }

        /// <summary>
        /// 案件分类标志，0 正常，1 删除
        /// </summary>
        int CategoryFlag { get; set; }
    }
}
