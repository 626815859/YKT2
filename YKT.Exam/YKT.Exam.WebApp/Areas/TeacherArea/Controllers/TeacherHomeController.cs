using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YKT.Exam.WebApp.Areas.TeacherArea.Controllers
{
    public class TeacherHomeController : Controller
    {
        // GET: TeacherArea/TeacherHome
        public ActionResult Index()
        {
            return View();
        }
    }
}