using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.Model;

namespace YKT.Exam.DAL
{
   public class StudentTestResultDal:BaseDal<StudentTestResult>
    {
        /// <summary>
        /// 根据试卷ID和学生ID返回试卷所有习题
        /// </summary>
        /// <param name="testPaperid">试卷ID</param>
        /// <param name="studentId">学生ID</param>
        /// <returns></returns>
        public List<StudentTestResult> GetResultListByTestPaperId(int testPaperid,int studentId)
        {
          return  Db.Set<StudentTestResult>().Where(u=>u.TestPaper.Id== testPaperid && u.Student.StudentId==studentId).ToList<StudentTestResult>();
        }
    }
}
