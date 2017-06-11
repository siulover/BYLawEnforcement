using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Case
    {
        //后台生成，
        [Key]
        public string CaseNo { get; set; }
        public string CaseName { get; set; }
        /// <summary>
        /// 违法投诉、欠费催缴、专项审计、信访、其他等案件的分类
        /// </summary>
        public string CaseCategory { get; set; }

        /// <summary>
        /// 案件标记，用于标记案件的类别，标记案件是社保投诉案件、监察农民工工资投诉案件等
        /// 仲裁案件或其他案件等。
        /// </summary>
        public string CaseMeta { get; set; }

        /// <summary>
        /// 投诉人ID
        /// </summary>
        public string CaseComplainantID { get; set; }
        public string CaseComplainantName { get; set; }
        public string CaseComplainantMobil { get; set; }
        public string CaseComplainantAdr { get; set; }
        /// <summary>
        /// 诉求
        /// </summary>
        public string CaseRequest { get; set; }
        /// <summary>
        /// 投诉日期
        /// </summary>
        public string CaseComplaintDate { get; set; }

        /// <summary>
        /// 被投诉组织或单位
        /// </summary>
        public string CaseBeComplaintOrg { get; set; }
        /// <summary>
        /// 被投诉组织负责人
        /// </summary>
        public string CaseBeComplaintOrgMg { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string CaseBeComplaintOrgMgTel { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string CaseBeComplaintOrgContact { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string CaseBeComplaintOrgContactTel { get; set; }
        /// <summary>
        /// 被投诉单位地址
        /// </summary>
        public string CaseBeComplaintAdr { get; set; }


        /// <summary>
        /// 录入人
        /// </summary>
        public string OfficialNo { get; set; }
        /// <summary>
        /// 案件状态标志。如是否结案、是否被删除等。0 正常，1 删除 2结案
        /// </summary>
        public int CaseFlag { get; set; }
        /// <summary>
        /// 案件终止原因，如：已经结案、案件无法继续进行等原因。
        /// </summary>
        public string CaseEndReason { get; set; }

    }
}
