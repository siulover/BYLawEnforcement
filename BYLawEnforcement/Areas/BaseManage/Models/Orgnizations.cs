using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BYLawEnforcement.Areas.BaseManage.Models
{
    /// <summary>
    /// 组织机构
    /// </summary>
    public class Orgnizations
    {
        /// <summary>
        /// 组织机构编号，一级部门不用设置编号，其以1000作为起点自动生成
        /// </summary>
        [Key]//单列整形的Key会被自动设置为标识列
        [Range(minimum:1000,maximum:9000)]
        public int OrgNo { get; set; }
        /// <summary>
        /// 组织机构名字
        /// </summary>
        [Required]
        [StringLength(50,MinimumLength =2,ErrorMessage = "{0}长度为{2}-{1}个字符")]
        [Display(Name ="组织机构名称")]
        public string OrgName { get; set; }

        
        /// <summary>
        /// 组织机构的职责
        /// </summary>
        public string OrgDuty { get; set; }
        /// <summary>
        /// 组织机构描述
        /// </summary>
        public string OrgDes { get; set; }

        ///// <summary>
        ///// 上级组织机构编号 
        ///// </summary>
        //public string UpOrgNo { get; set; }


        /// <summary>
        /// 0 正常，1 删除
        /// </summary>
        public int OrgFlag { get; set; }

        
    }
}
