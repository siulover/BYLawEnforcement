using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    /// <summary>
    /// 案件类别， 违法投诉、欠费催缴、专项审计、信访、其他等案件的分类
    /// </summary>
    public class CaseCategory
    {
        [Key]
        public int CategoryNo { get; set; }
        public string CategoryName { get; set; }

        /// <summary>
        /// 案件分类标志，0 正常，1 删除
        /// </summary>
        public int CategoryFlag { get; set; }
    }
}
