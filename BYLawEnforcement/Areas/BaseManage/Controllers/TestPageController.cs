using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BYLawEnforcement.Areas.BaseManage.Controllers
{
    public class TestPageController : Controller
    {
        // GET: BaseManage/TestPage
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}