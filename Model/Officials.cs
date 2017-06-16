using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name = "编号")]
        public int OffNo { get; set; }
        [Display(Name ="姓名")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0}长度为{2}-{1}个字符")]
        public string Offname { get; set;}
        [ForeignKey("Dept")]
        [Required]
        [Display(Name = "部门编号")]
        public int DepNo { get; set; }
        [Required]
        [RegularExpression("^1[3|5|7|8]\\d{9}$",ErrorMessage ="请输入正确的手机号")]
        [Display(Name = "手机号")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "请输入您的密码")]
        [StringLength(50, ErrorMessage = "密码的长度必须大于6个字符。", MinimumLength = 6)]
        public string OffPwd { get; set; }
        /// <summary>
        /// 执法证号
        /// </summary>
        [Display(Name ="执法证号")]
        public string LawForcementNo { get; set; }
        /// <summary>
        /// 标志位，0标识正常，1表示删除
        /// </summary>
        public int OfficialFlag { get; set; }

        public virtual Departments Dept { get; set; }

    }
}
