using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YKT.Exam.BLL;
using YKT.Exam.Model;
using YKT.Exam.WebApp.Models;

namespace YKT.Exam.WebApp.Areas.TeacherArea.Controllers
{
    public class BaseTestPaperListController : Controller
    {
        BaseTestPaperService baseTestPaperService = new BaseTestPaperService();
        StudentService studentService = new StudentService();
        CourseService courseService = new CourseService();
        TestPaperService testPaperService = new TestPaperService();
        // GET: TeacherArea/BaseTestPaperList
        public ActionResult Index()
        {
            ClassCourseViewModels classCourseViewModels = new ClassCourseViewModels();
            List<Course> listCourse = courseService.GetCourseInfo();  //获取科目
            List<Class> listClass = studentService.GetClassInfo();  //获取班级
            classCourseViewModels.CourseList = listCourse;
            classCourseViewModels.ClassList = listClass;
            ViewBag.classCourseViewModels = classCourseViewModels;
            return View();
        }

        public ActionResult GetBaseTestPaperAllInfo()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;


            int totalCount = baseTestPaperService.GetTotal();
            //获取分页数据。
            var baseTestPaperList = baseTestPaperService.GetAllRoles(pageIndex, pageSize);

            List<BaseTestPaperViewModels> BaseTestPaperViewModelsList = new List<BaseTestPaperViewModels>();
            foreach (var item in baseTestPaperList)
            {
                BaseTestPaperViewModelsList.Add(new BaseTestPaperViewModels()
                {
                    ViewBaseTestPaperId = item.Id,                      //ID
                    ViewBaseTestPaperName = item.BaseTestPaperName,   //名字
                    ViewBaseTestPaperType = item.BaseTestPaperType,   //类型备注
                    ViewBaseTestPaperCreateTime = item.BaseTestPaperCreateTime,  //创建时间
            
                });
            }

            return Json(new { rows = BaseTestPaperViewModelsList, total = totalCount }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 发布试卷
        /// </summary>
        /// <returns></returns>
        public ActionResult CreatSendPaper()
        {
            int stubaseTestPaperId =Convert.ToInt32(Request["stubaseTestPaperId"]);
            int stuClassId= Convert.ToInt32(Request["stuClassId"]);
            int stuCourseId= Convert.ToInt32(Request["stuCourseId"]);
           
            DateTime StartTime = DateTime.Parse(Request["StartTime"]);
            DateTime EndTime = DateTime.Parse(Request["EndTime"]);

            //找到该班级下面的所有学生Id
            int[] stuIds= studentService.GetAllStudentIdByClassId(stuClassId);
            //为该班级下的每个学生发布试题
            bool b = false;
            for (int i = 0; i < stuIds.Length; i++)
            {
                TestPaper testPaper = new TestPaper()
                {
                    TestPaperStartTime = StartTime,
                    TestPaperEndTime = EndTime,
                };
                testPaper.Course = courseService.GetModelById(stuCourseId);
                testPaper.Student = studentService.GetModelById(stuIds[i]);
                testPaper.BaseTestPaper = baseTestPaperService.GetModelById(stubaseTestPaperId);
                if(testPaperService.Add(testPaper))
                {
                    b = true;
                }
                else
                {
                    b = false;
                }
            }
            if (b == true)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }


        }

    }
}