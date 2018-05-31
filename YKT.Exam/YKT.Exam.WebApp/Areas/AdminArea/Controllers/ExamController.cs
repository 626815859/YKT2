using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using YKT.Exam.BLL;
using YKT.Exam.Model;

namespace YKT.Exam.WebApp.Areas.AdminArea.Controllers
{
    

    public class ExamController : Controller
    {
        StudentTestResultService studentTestResultService = new StudentTestResultService();
        TestQuestionService testQuestionService = new TestQuestionService();
        PaperQuestionService paperQuestionService = new PaperQuestionService();
        // GET: AdminArea/Exam
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 选择题分数，判断题，填空题分数，简答题分数,总分
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTestCourse()
        {
            //或得考生的ID，试卷ID
            int testPaperid = Convert.ToInt32(Request["testPaperid"]);
            int studentId = Convert.ToInt32(Request["studentId"]);

            //学生的作答实体
            List<StudentTestResult> studentTestResultListModel = new List<StudentTestResult>();
            studentTestResultListModel = studentTestResultService.GetResultListByTestPaperId(testPaperid, studentId);

            Dictionary<int, StudentTestResult> studentTestResultDicModel = new Dictionary<int, StudentTestResult>();
            foreach (StudentTestResult item in studentTestResultListModel)
            {
                studentTestResultDicModel.Add(item.Id, item);
            }

            //或得该试卷下的所有试题ID
            List<int> paperQuestionIdList = paperQuestionService.GetTestQueationListByBaseTestPaperId(testPaperid);

            //根据试题ID从题库中找到试题实体（包括答案，分数，类型等）,再进行与学生的答案比对
            Dictionary<int, TestQuestion> TestQuestionDic = new Dictionary<int, TestQuestion>();
            foreach (int item in paperQuestionIdList)
            {
                TestQuestionDic.Add(item,testQuestionService.GetModelById(item));
            }

            //进行比对判分
            Dictionary<string, int> fenShu = GetTestSumSoure(studentTestResultDicModel, TestQuestionDic);

            ViewBag.studentTestSourse = fenShu;

            return View();
        }


        /// <summary>
        /// 评分
        /// </summary>
        /// <param name="studentTestResultDicModel">学生的答案</param>
        /// <param name="TestQuestionDict">正确的答案</param>
        /// <returns>成绩</returns>
        public Dictionary<string,int> GetTestSumSoure(Dictionary<int, StudentTestResult> studentTestResultDicModel, Dictionary<int, TestQuestion> TestQuestionDict)
        {
            int sum = 0;
            int xZt = 0;
            int pDt = 0;
            int tKT = 0;
            int jDT = 0;
            foreach (KeyValuePair<int, TestQuestion> k in TestQuestionDict)
            {
                switch(k.Value.TestQuestionType)
                {
                    case "选择题":
                        if (k.Value.TestQuestionResult == studentTestResultDicModel[k.Key].QuestionResult)
                        {
                            xZt += Convert.ToInt32(k.Value.TestQuestionGrade);
                        }
                        ; break;
                    case "判断题":
                        if(k.Value.TestQuestionResult== studentTestResultDicModel[k.Key].QuestionResult)
                        {
                            pDt += Convert.ToInt32(k.Value.TestQuestionGrade);
                        }
                        ; break;
                    case "填空题":
                        if(k.Value.TestQuestionResult== studentTestResultDicModel[k.Key].QuestionResult)
                        {
                            tKT += Convert.ToInt32(k.Value.TestQuestionGrade);
                        }
                        ; break;
                    case "简答题":
                        //将正确答案分割为关键字数组
                        string[] queationReaaultStrArray = Regex.Split(k.Value.TestQuestionResult,"&$",RegexOptions.IgnoreCase);
                        //在学生的答案中遍历检索
                        foreach (string item in queationReaaultStrArray)   
                        {
                           if(studentTestResultDicModel[k.Key].QuestionResult.IndexOf(item)>0)  //含有关键字
                            {
                                jDT += (1 / queationReaaultStrArray.Length * Convert.ToInt32(k.Value.TestQuestionGrade));  //一个关键字的分数等于1/所有关键字*该题总分
                            }
                           else
                            {
                                continue;
                            }
                        }
                        ; break;   //关键词检索
                    default: break;
                }
            }
            sum = xZt + pDt + tKT + jDT;
            Dictionary<string, int> dic = new Dictionary<string, int>
            {
                {"选择题", xZt},
                {"判断题", pDt},
                {"填空题", tKT},
                {"简答题", jDT},
                {"总分",sum }

            };           
            return dic;
        }

    }
}