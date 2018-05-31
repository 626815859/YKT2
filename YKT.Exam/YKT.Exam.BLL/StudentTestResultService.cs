using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.DAL;
using YKT.Exam.Model;

namespace YKT.Exam.BLL
{
    public class StudentTestResultService : BaseService<StudentTestResult>
    {
        StudentTestResultDal studentTestResultDal = new StudentTestResultDal();
        public override void SetDal()
        {
            Dal = studentTestResultDal;
        }
        /// <summary>
        /// 根据试卷ID和学生ID返回试卷所有习题
        /// </summary>
        /// <param name="testPaperid">试卷ID</param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public List<StudentTestResult> GetResultListByTestPaperId(int testPaperid, int studentId)
        {
            return studentTestResultDal.GetResultListByTestPaperId(testPaperid, studentId);
        }
    }
}
