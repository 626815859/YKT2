using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YKT.Exam.WebApp.Areas.StudentArea.Controllers
{
    public class StudentHomeController : Controller
    {
        // GET: StudentArea/StudentHome
        public ActionResult Index()
        {
            return View();
        }
    }
}