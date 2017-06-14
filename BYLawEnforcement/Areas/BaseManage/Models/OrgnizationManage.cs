using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LE.Common;
using LE.Core;
using LE.IDAL;
using LinqKit;
using System.Linq.Expressions;
using Model;
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
            if (!string.IsNullOrWhiteSpace(entity.OrgName)&& HasName(entity.OrgName))
            {
                _resp.Code = 2;
            }
            if (_resp.Code == 0)
            {
                _resp = base.Add(entity);
            }
            return _resp;
        }
        /// <s.urns></returns>
        public override Orgnizations Find(int ID)
        {
            var _where = PredicateBuilder.New<Orgnizations>(true);
            _where = _where.And(u => u.OrgNo == ID);
            _where = _where.And(u => u.OrgFlag != 1);
            return base.Repositorys.Find(_where);
        }
        /// <summary>
        /// 查询组织机构列表带分页方法
        /// </summary>
        /// <param name="pageOrg">分页数据</param>
        /// <param name="orgName">组织机构名</param>
        /// <param name="order">？表示该值可以为空，排序【null（默认）-NO降序，0-NO升序，1-名称降序，2-名称升序】</param>
        /// <returns></returns>
        public Paging<Orgnizations> FindPageList(Paging<Orgnizations> pageOrg, int? order)
        {
           //PredicateBuilder是一个Lamda表达式的述语（谓词）生成器，New方法是新版本的开始生成一个Lamda表达式，其中New（true）替代原来的True（）
           //true表示生成and组合， false表示生成or组合。
            var _where = PredicateBuilder.New<Orgnizations>(true);
            //if (!string.IsNullOrEmpty(orgName))
            //{
                //_where = _where.And(u => u.OrgName == orgName);
                _where = _where.And(u => u.OrgFlag != 1);
            //}

            bool _asc = false;

            Expression<Func<Orgnizations, string>> _ord;
            switch (order)
            {
                case 0:
                    pageOrg.Items = Repository.FindPageList(pageOrg.PageSize, pageOrg.PageIndex,out pageOrg.TotalNumber, _where, u=>u.OrgNo,_asc).ToList();
                    break;
                case 1:
                    _ord = u => u.OrgName;
                    _asc = true;
                    break;
                case 2:
                    _ord = u => u.OrgName;
                    _asc = true;
                    break;
                default:
                    _ord = u => u.OrgName;
                    _asc = true;
                    break;

            }

            pageOrg.Items =Repository.FindPageList(pageOrg.PageSize, pageOrg.PageIndex, out pageOrg.TotalNumber, _where,u => u.OrgName, _asc).ToList();

            return pageOrg;
        }
        /// <summary>
        /// 为确保关联数据不出错，更新标志位为1
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Response Remove(int ID)
        {
            Orgnizations org = Find(ID);
            org.OrgFlag = 1;
            Response _resp= base.Update(org);
            
            return _resp;

        }

        /// <summary>
        /// 组织机构名是否存在
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