using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Departments
    {
        [Key]
        [Display(Name ="部门编号")]
        public int DepartNo { get; set; }
        [Required]
        [StringLength(50,MinimumLength =2,ErrorMessage = "{0}长度为{2}-{1}个字符")]
        [Display(Name ="部门名称")]
        public string DepartName { get; set; }
        [Required]
        [Display(Name ="机构编号")]
        public int OrgNo { get; set; }
        /// <summary>
        /// 部门标志位0正常，1删除。
        /// </summary>
        public int DepartmentFlag { get; set; }
        public Orgnizations Org { get; set; }
    }
}
