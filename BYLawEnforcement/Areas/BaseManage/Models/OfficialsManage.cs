using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LE.Core;
using LE.Common;
using LinqKit;
using System.Linq.Expressions;

namespace BYLawEnforcement.Areas.BaseManage.Models
{
    public class OfficialsManage:LE.Core.BaseManager<Model.Officials>
    {
        /// <summary>
        /// 添加[返回值Response是自定义的返回类型。其中Response.Code 0 表示添加失败，1表示添加成功，2表示部门已经存在]
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override Response Add(Model.Officials entity)
        {

            Response _resp = new Response();
            if (!string.IsNullOrWhiteSpace(entity.Offname) && base.Repositorys.IsContains(u => u.Offname.ToUpper() == entity.Offname.ToUpper()))
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
        public override Model.Officials Find(int ID)
        {
            var _where = PredicateBuilder.New<Model.Officials>(true);
            _where = _where.And(u => u.OffNo == ID);
            _where = _where.And(u => u.OfficialFlag != 1);
            return base.Repositorys.Find(_where);
        }
        /// <summary>
        /// 查询组织机构列表带分页方法
        /// </summary>
        /// <param name="pageDpt">分页数据</param>
        /// <param name="orgName">组织机构名</param>
        /// <param name="order">？表示该值可以为空，排序【null（默认）-NO降序，0-NO升序，1-名称降序，2-名称升序】</param>
        /// <returns></returns>
        public Paging<Model.Officials> FindPageList(Paging<Model.Officials> pageDpt, int? order)
        {
            //PredicateBuilder是一个Lamda表达式的述语（谓词）生成器，New方法是新版本的开始生成一个Lamda表达式，其中New（true）替代原来的True（）
            //true表示生成and组合， false表示生成or组合。
            var _where = PredicateBuilder.New<Model.Officials>(true);
            //if (!string.IsNullOrEmpty(orgName))
            //{
            //_where = _where.And(u => u.OrgName == orgName);
            _where = _where.And(u => u.OfficialFlag != 1);
            //}

            bool _asc = false;

            Expression<Func<Model.Officials, string>> _ord;
            switch (order)
            {
                case 0:
                    pageDpt.Items = Repository.FindPageList(pageDpt.PageSize, pageDpt.PageIndex, out pageDpt.TotalNumber, _where, u => u.OffNo, _asc).ToList();

                    break;
                case 1:
                    _ord = u => u.Offname;
                    _asc = true;
                    break;
                case 2:
                    _ord = u => u.Offname;
                    _asc = true;
                    break;
                default:
                    _ord = u => u.Offname;
                    _asc = false;
                    break;

            }

            pageDpt.Items = Repository.FindPageList(pageDpt.PageSize, pageDpt.PageIndex, out pageDpt.TotalNumber, _where, u => u.OffNo, _asc).ToList();

            return pageDpt;
        }
        /// <summary>
        /// 为确保关联数据不出错，更新标志位为1
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Response Remove(int ID)
        {
            Model.Officials _offcia = Find(ID);
            _offcia.OfficialFlag = 1;
            Response _resp = base.Update(_offcia);

            return _resp;

        }
    }
}