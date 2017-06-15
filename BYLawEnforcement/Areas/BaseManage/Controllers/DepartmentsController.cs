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
    public class DepartmentsController : Controller
    {
        private DepartmentManage  db = new DepartmentManage();

        // GET: BaseManage/Departments
        public ActionResult Index()
        {
            Paging<Departments> pages = new Paging<Departments>();
            pages.PageSize = 5;
            db.FindPageList(pages, null);
            
            return View(pages.Items);
        }

        // GET: BaseManage/Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Find((int)id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        // GET: BaseManage/Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaseManage/Departments/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartNo,DepartName,OrgNo,DepartmentFlag")] Departments departments)
        {
            
            if (ModelState.IsValid)
            {
                db.Add(departments);
               
                return RedirectToAction("Index");
            }

            return View(departments);
        }

        // GET: BaseManage/Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Departments departments = db.Find((int)id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            OrgnizationManage _orgMg = new OrgnizationManage();
            Paging<Orgnizations> _page = new Paging<Orgnizations>();
            _orgMg.FindPageList(_page, null);
            ViewBag.temp= new SelectList(_page.Items, "OrgNo", "OrgName");
            //ViewData["temp"] =new SelectList(_page.Items, "OrgNo", "OrgName");
            return View(departments);
        }

        // POST: BaseManage/Departments/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartNo,DepartName,OrgNo,DepartmentFlag")] Departments departments)
        {
            if (ModelState.IsValid)
            {
                db.Update(departments);
                return RedirectToAction("Index");
            }
            return View(departments);
        }

        // GET: BaseManage/Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Find((int)id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        // POST: BaseManage/Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            db.Remove(id);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Repositorys.DbContext.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
