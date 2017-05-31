using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Case
    {
        string CaseNo { get; set; }
        string CaseName { get; set; }
        /// <summary>
        /// 违法投诉、欠费催缴、专项审计、信访、其他等案件的分类
        /// </summary>
        string CaseCategory { get; set; }

        /// <summary>
        /// 案件标记，用于标记案件的类别，标记案件是社保案件、监察案件、
        /// 仲裁案件或其他案件等。
        /// </summary>
        string CaseMeta { get; set; }

        /// <summary>
        /// 投诉人ID
        /// </summary>
        string CaseComplainantID { get; set; }
        string CaseComplainantName { get; set; }
        string CaseComplainantMobil { get; set; }
        string CaseComplainantAdr { get; set; }
        /// <summary>
        /// 诉求
        /// </summary>
        string CaseRequest { get; set; }
        /// <summary>
        /// 投诉日期
        /// </summary>
        string CaseComplaintDate { get; set; }

        /// <summary>
        /// 被投诉组织或单位
        /// </summary>
        string CaseBeComplaintOrg { get; set; }
        /// <summary>
        /// 被投诉组织负责人
        /// </summary>
        string CaseBeComplaintOrgMg { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        string CaseBeComplaintOrgMgTel { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        string CaseBeComplaintOrgContact { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        string CaseBeComplaintOrgContactTel { get; set; }
        /// <summary>
        /// 被投诉单位地址
        /// </summary>
        string CaseBeComplaintAdr { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        string OfficialNo { get; set; }

        /// <summary>
        /// 案件状态标志。如是否结案、是否被删除等。
        /// </summary>
        int Flag { get; set; }
        /// <summary>
        /// 案件终止原因，如：已经结案、案件无法继续进行等原因。
        /// </summary>
        string CaseEndReason { get; set; }

    }
}
