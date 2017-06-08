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
namespace BYLawEnforcement.Areas.BaseManage.Controllers
{
    public class OrgnizationsController : Controller
    {
        private OrgnizationManage db = new OrgnizationManage();

        // GET: BaseManage/Orgnizations
        public ActionResult Index()
        {

            return View(db.FindList());
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
            orgnizations.OrgFlag = 0;
            orgnizations.OrgNo = 1;
            //if (ModelState.IsValid)
            //{
                orgnizations.OrgFlag = 0;
                db.Add(orgnizations);
                db.Repositorys.Save();//.SaveChanges();
                //return RedirectToAction("Index");
            //}

            return View(orgnizations);
        }

        //        // GET: BaseManage/Orgnizations/Edit/5
        //        public ActionResult Edit(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            Orgnizations orgnizations = db.Orgnizations.Find(id);
        //            if (orgnizations == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(orgnizations);
        //        }

        //        // POST: BaseManage/Orgnizations/Edit/5
        //        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        //        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Edit([Bind(Include = "OrgNo,OrgName,OrgDuty,OrgDes,OrgFlag")] Orgnizations orgnizations)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Entry(orgnizations).State = EntityState.Modified;
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            return View(orgnizations);
        //        }

        //        // GET: BaseManage/Orgnizations/Delete/5
        //        public ActionResult Delete(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            Orgnizations orgnizations = db.Orgnizations.Find(id);
        //            if (orgnizations == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(orgnizations);
        //        }

        //        // POST: BaseManage/Orgnizations/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult DeleteConfirmed(int id)
        //        {
        //            Orgnizations orgnizations = db.Orgnizations.Find(id);
        //            db.Orgnizations.Remove(orgnizations);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        protected override void Dispose(bool disposing)
        //        {
        //            if (disposing)
        //            {
        //                db.Dispose();
        //            }
        //            base.Dispose(disposing);
        //        }
    }
}
