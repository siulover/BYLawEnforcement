using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYLawEnforcement.Areas.BaseManage.Models
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Departments
    {
        public string DepartNo { get; set; }

        public string DepartName { get; set; }

        public string OrgNo { get; set; }
        public int DepartmentFlag { get; set; }
    }
}
