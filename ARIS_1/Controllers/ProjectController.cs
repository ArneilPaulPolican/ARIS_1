using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARIS_1.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Students()
        {
            return View();
        }
        public ActionResult Subjects()
        {
            return View();
        }

    }
}