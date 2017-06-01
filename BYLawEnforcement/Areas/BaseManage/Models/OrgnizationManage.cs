using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LE.Common;
using LE.Core;
using LE.IDAL;

namespace BYLawEnforcement.Areas.BaseManage.Models
{
    public class OrgnizationManage:BaseManager<Orgnizations>
    {
        /// <summary>
        /// 添加[返回值Response是自定义的返回类型。其中Response.Code 0 表示添加失败，1表示添加成功，2表示部门已经存在]
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override Response Add(Orgnizations entity)
        {
            Response _resp = new Response();
            if (!string.IsNullOrWhiteSpace(entity.OrgName)&&HasUsername(entity.OrgName))
            {
                _resp.Code = 2;
            }

            return base.Add(entity);
        }


        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="accounts">用户名[不区分大小写]</param>
        /// <returns></returns>
        public bool HasName(string name)
        {
            //u => u.OrgName.ToUpper() == username.ToUpper()  "=>"标志为匿名函数，u为传入的参数，u.OrgName.ToUpper() == username.ToUpper()为函数体。
            //如x=>Console.writeln(x);类似的感觉
            //只有在Lambda有一个输入参数时，括号才是可选的；否则括号是必需的。两个或更多输入参数由括号中的逗号分隔:
            //(x, y) => x == y
           
            
            return base.Repositorys.IsContains(u => u.OrgName.ToUpper() == name.ToUpper());
        }
    }
}