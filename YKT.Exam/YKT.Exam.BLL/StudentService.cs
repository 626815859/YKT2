using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.DAL;
using YKT.Exam.Model;

namespace YKT.Exam.BLL
{
    public class StudentService : BaseService<Student>
    {
        private StudentDal StudentDal = new StudentDal();
        public override void SetDal()
        {
            Dal = StudentDal;
        }

        /// <summary>
        /// 根据Id获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetModelById(int id)
        {
            return StudentDal.GetModelById(id);
        }

        /// <summary>
        /// 获取指定班级的所有学生Id
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public int[] GetAllStudentIdByClassId(int classId)
        {
           return StudentDal.GetAllStudentIdByClassId(classId);
        }
        /// <summary>
        /// 获取学生所有的考试信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetTestTotal(int studentId)
        {
            return StudentDal.GetTestTotal(studentId);
        }
        /// <summary>
        /// 获取学生考试分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public List<TestPaper> GetTestAllRoles(int page, int rows, int studentId)
        {
            return StudentDal.GetTestAllRoles(page, rows, studentId);
        }


        /// <summary>
        /// 获取学生的所有考试
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TestPaper> GetAllTest(int id)
        {
            return StudentDal.GetAllTest(id);
        }

        /// <summary>
        /// 获取学生的班级信息
        /// </summary>
        /// <returns></returns>
        public List<Class> GetClassInfo()
        {
            return StudentDal.GetClassInfo();
        }

        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        public Student GetUserInfo(string userName, string userPwd)
        {
            return StudentDal.GetUserInfo(userName, userPwd);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public List<Student> GetAllRoles(int page, int rows)
        {
            return StudentDal.GetAllRoles(page, rows);
        }
        public List<Student> GetAllRolesByClassId(int page, int rows, int classId)
        {

            return StudentDal.GetAllRolesByClassId(page, rows,classId);
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            return StudentDal.GetTotal();
        }
        public int GetTotalByClassId(int classId)
        {
            return StudentDal.GetTotalByClassId(classId);
        }
    }
}
