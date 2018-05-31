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
    public class TestQuestionListController : Controller
    {
        TestQuestionService testQuestionService = new TestQuestionService();
        BaseTestPaperService baseTestPaperService = new BaseTestPaperService();
        PaperQuestionService paperQuestionService = new PaperQuestionService();
  

        // GET: TeacherArea/TestQuestionList
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult GetTestQuestionAllInfo()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int classId = int.Parse(Request["ViewTestQuestionId"]);


            int totalCount = testQuestionService.GetTotal();
            //获取分页数据。
            var userList = testQuestionService.GetAllRoles(pageIndex, pageSize);

            List<TestQuestionViewModels> TestQuestionViewModelsList = new List<TestQuestionViewModels>();
            foreach (var item in userList)
            {
                TestQuestionViewModelsList.Add(new TestQuestionViewModels()
                {
                    ViewTestQuestionId=item.Id,                      //ID
                    ViewTestQuestionType = item.TestQuestionType,   //类型
                    ViewTestQuestionName = item.TestQuestionName,   //题名
                    ViewTestQuestionGrade = item.TestQuestionGrade,  //分数
                    ViewTestQuestionResult=item.TestQuestionResult    //答案
                });
            }
            return Json(new { rows = TestQuestionViewModelsList, total = totalCount }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增试题
        /// </summary>
        /// <param name="addTestQuestionViewModel"></param>
        /// <returns></returns>
        public ActionResult AddTestQuestion(addTestQuestionViewModel addTestQuestionViewModel)
        {
            bool b =false;
            TestQuestion testQuestion = new TestQuestion();
            if (addTestQuestionViewModel.ViewTestQuestionType==0.ToString())   //选择题
            {
                testQuestion.TestQuestionType = addTestQuestionViewModel.ViewTestQuestionType;   //类型
                //问题&$答案A....
                testQuestion.TestQuestionName = string.Format("{0}&${1}&${2}&${3}&${4}", addTestQuestionViewModel.ViewTestQuestionName, addTestQuestionViewModel.optionA, addTestQuestionViewModel.optionB, addTestQuestionViewModel.optionC, addTestQuestionViewModel.optionD);
                testQuestion.TestQuestionResult = addTestQuestionViewModel.ViewTestQuestionResult;   //答案
                testQuestion.TestQuestionGrade = addTestQuestionViewModel.ViewTestQuestionGrade;      //分值
                b = testQuestionService.Add(testQuestion);
            }
            else   //非选择题(判断题用 y或者x表示)
            {
                testQuestion.TestQuestionType = addTestQuestionViewModel.ViewTestQuestionType;   //类型
                testQuestion.TestQuestionName = addTestQuestionViewModel.ViewTestQuestionName;    //问题
                testQuestion.TestQuestionResult = addTestQuestionViewModel.ViewTestQuestionResult;   //答案
                testQuestion.TestQuestionGrade = addTestQuestionViewModel.ViewTestQuestionGrade;      //分值
                b=testQuestionService.Add(testQuestion);
            }
            if(b==true)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }

        }

        /// <summary>
        /// 删除试题
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteTestQuestions()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (string id in strIds)
            {
                list.Add(Convert.ToInt32(id));
            }
            if (testQuestionService.DeleteEntities(list))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        /// <summary>
        /// 组合成试卷
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreatBaseTestPaper()
        {
            string strId = Request["strId"];
            string baseTestPaperName = Request["baseTestPaperName"];
            string baseTestPaperType = Request["baseTestPaperType"];
            BaseTestPaper baseTestPaper = new BaseTestPaper()
            {
                BaseTestPaperName = baseTestPaperName,
                BaseTestPaperType = baseTestPaperType,
                BaseTestPaperCreateTime = DateTime.Now
            };
            baseTestPaperService.Add(baseTestPaper);                     
            string[] strIds = strId.Split(',');   //选中的试题数组
            foreach (string id in strIds)
            {               
                TestQuestion testQuestion = testQuestionService.GetModelById(Convert.ToInt32(id));
                PaperQuestion paperQuestion = new PaperQuestion();
                paperQuestion.BaseTestPaper = baseTestPaper;
                paperQuestion.TestQuestion = testQuestion;
                paperQuestionService.Add(paperQuestion);             
            }
            return Content("ok");
        }

    }
}