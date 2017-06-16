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
    public class OfficialsController : Controller
    {
        private OfficialsManage  db = new OfficialsManage();

        // GET: BaseManage/Officials
        public ActionResult Index()
        {
            Paging<Officials> _page = new Paging<Officials>();
            db.FindPageList(_page, null);
            
            return View(_page.Items);
        }

        // GET: BaseManage/Officials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Officials officials = db.Find((int)id);
            if (officials == null)
            {
                return HttpNotFound();
            }
            return View(officials);
        }

        /// <summary>
        /// 获取部门列表信息
        /// </summary>
        /// <returns></returns>
        public List<Departments> getDepts()
        {
            DepartmentManage _dptMg = new DepartmentManage();
            Paging<Departments> _page = new Paging<Departments>();
            _dptMg.FindPageList(_page, null);
            return _page.Items;
        }

        // GET: BaseManage/Officials/Create
        public ActionResult Create()
        {
            ViewBag.dpt = new SelectList(getDepts(), "DepartNo","DepartName","--请选择部门--");
            return View();
        }

        // POST: BaseManage/Officials/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OffNo,Offname,DepNo,MobileNo,OffPwd,LawForcementNo,OfficialFlag")] Officials officials)
        {
            if (ModelState.IsValid)
            {
                db.Add(officials);
                return RedirectToAction("Index");
            }
          
            ViewBag.dpt = new SelectList(getDepts(), "DepartNo", "DepartName", officials.DepNo);
            return View(officials);
        }

        // GET: BaseManage/Officials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Officials officials = db.Find((int)id);
            if (officials == null)
            {
                return HttpNotFound();
            }
          
            ViewBag.dpt = new SelectList(getDepts(), "DepartNo", "DepartName", officials.DepNo);
            return View(officials);
        }

        // POST: BaseManage/Officials/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OffNo,Offname,DepNo,MobileNo,OffPwd,LawForcementNo,OfficialFlag")] Officials officials)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(officials).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.DepNo = new SelectList(db.Departments, "DepartNo", "DepartName", officials.DepNo);
            return View(officials);
        }

        // GET: BaseManage/Officials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Officials officials = db.Find((int)id);
            if (officials == null)
            {
                return HttpNotFound();
            }
            return View(officials);
        }

        // POST: BaseManage/Officials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Officials officials = db.Find((int)id);
            db.Remove(id);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
