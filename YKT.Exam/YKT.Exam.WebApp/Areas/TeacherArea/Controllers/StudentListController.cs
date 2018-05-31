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
    public class StudentListController : Controller
    {
        StudentService studentService = new StudentService();
        // GET: TeacherArea/StudentList

        public ActionResult Index()
        {
            List<Class> listClass = studentService.GetClassInfo();
            ViewBag.listClass = listClass;
            return View();
        }
        [HttpPost]
        public ActionResult GetStuInfoList()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int classId = int.Parse(Request["classId"]);
            if(classId==-1)  //表示加载全部
            {
                //总记录数
                int totalCount = studentService.GetTotal();
                //获取分页数据。
                var userList = studentService.GetAllRoles(pageIndex, pageSize);
                List<StudentViewModels> stuViewList = new List<StudentViewModels>();
                foreach (var item in userList)
                {
                    stuViewList.Add(new StudentViewModels()
                    {
                        StudentId = item.StudentId,
                        StudentName = item.StudentName,
                        StudentClassName = item.Class.ClassName
                    });
                }
                //rows total是固定的，不能随便取,前台只需要分页数据，总记录数
                return Json(new { rows = stuViewList, total = totalCount }, JsonRequestBehavior.AllowGet);
            }
            else  //加载对应班级的学生
            {
                //总记录数
                int totalCount = studentService.GetTotalByClassId(classId);
                //获取分页数据。
                var userList = studentService.GetAllRolesByClassId(pageIndex, pageSize,classId);
                List<StudentViewModels> stuViewList = new List<StudentViewModels>();              
                foreach (var item in userList)
                {
                    stuViewList.Add(new StudentViewModels()
                    {
                        StudentId = item.StudentId,
                        StudentName = item.StudentName,
                        StudentClassName = item.Class.ClassName
                    });
                }
                //rows total是固定的，不能随便取,前台只需要分页数据，总记录数
                return Json(new { rows = stuViewList, total = totalCount }, JsonRequestBehavior.AllowGet);
            }
       
        }
        /// <summary>
        /// 学生考试详情
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentAllTest()
        {
            //int StudentId = int.Parse(Request.QueryString["StudentId"]);
            //List<TestPaper> listTestPaper= studentService.GetAllTest(StudentId);
            //ViewBag.listTestPaper = listTestPaper;
            return View();
        }



        /// <summary>
        /// 获取学生所有的考试记录
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStuTestInfo()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int studentId = int.Parse(Request["studentId"]);
            //总记录数
            int totalCount = studentService.GetTestTotal(studentId);
            //获取分页数据。
            var userList = studentService.GetTestAllRoles(pageIndex, pageSize,studentId);         
            //rows total是固定的，不能随便取,前台只需要分页数据，总记录数
            return Json(new { rows = userList, total = totalCount }, JsonRequestBehavior.AllowGet);
        }

    }
}