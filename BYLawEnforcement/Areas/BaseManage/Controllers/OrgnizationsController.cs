using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LE.Core;
using Model;
using BYLawEnforcement.Areas.BaseManage.Models;
using LE.Common;
namespace BYLawEnforcement.Areas.BaseManage.Controllers
{
    public class OrgnizationsController : Controller
    {
        private OrgnizationManage db = new OrgnizationManage();

        // GET: BaseManage/Orgnizations
        public ActionResult Index()
        {
            Paging<Orgnizations> page = new Paging<Orgnizations>();
            page.PageSize = 5;
            db.FindPageList(page,null);
            
            return View(page.Items);
        }

        // GET: BaseManage/Orgnizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orgnizations orgnizations = db.Find((int)id);
            if (orgnizations == null)
            {
                return HttpNotFound();
            }
            return View(orgnizations);
        }

        // GET: BaseManage/Orgnizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaseManage/Orgnizations/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrgName,OrgDuty,OrgDes")] Orgnizations orgnizations)
        {
            //orgnizations.OrgFlag = 0;
            //orgnizations.OrgNo = 1;
            Response _resp=null;
            if (ModelState.IsValid)
            {
                //orgnizations.OrgFlag = 0;
                 _resp= db.Add(orgnizations);
                if (_resp.Code == 1)
                    return RedirectToAction("Index");
                else
                    _resp.Data = orgnizations;
            }

            return View(_resp);
        }

        // GET: BaseManage/Orgnizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orgnizations orgnizations = db.Find((int)id);
            if (orgnizations == null)
            {
                return HttpNotFound();
            }
            return View(orgnizations);
        }

        // POST: BaseManage/Orgnizations/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "OrgNo,OrgName,OrgDuty,OrgDes")] Orgnizations orgnizations)
        {
            Response _resp = new Response();
            _resp.Code = 0;
            _resp.Message = "更新组织机构错误";
            if (ModelState.IsValid)
            {
                _resp= db.Update(orgnizations);//..Entry(orgnizations).State = EntityState.Modified;
                //db.SaveChanges();
                //if(_resp.Code==1)
                //    return RedirectToAction("Index");
            }
            //Json()
            return Json(_resp);
        }

        // GET: BaseManage/Orgnizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orgnizations orgnizations = db.Find((int)id);
            if (orgnizations == null)
            {
                return HttpNotFound();
            }
            return View(orgnizations);
        }

        // POST: BaseManage/Orgnizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Orgnizations orgnizations = db.Find(id);
            db.Remove(id);
            //db.Repositorys.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Repositorys.DbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
