using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.Model;

namespace YKT.Exam.DAL
{
    //继承基类BaseDal共有的方法
    public class StudentDal : BaseDal<Student>
    {
        //自己特有的方法



        /// <summary>
        /// 根据Id获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetModelById(int id)
        {
            return Db.Set<Student>().Where(u => u.StudentId == id).SingleOrDefault();
        }


        /// <summary>
        /// 获取指定班级的所有学生Id
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public int[] GetAllStudentIdByClassId(int classId)
        {
            var ids = (from u in Db.Set<Student>()
                       where u.Class.Id == classId
                       select u.StudentId).ToArray();
            return ids;
        }

        /// <summary>
        /// 获取学生的所有考试
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TestPaper> GetAllTest(int id)
        {
            return Db.Set<TestPaper>().Where(u => u.Student.StudentId == id).ToList();
        }

        /// <summary>
        /// 获取班级信息
        /// </summary>
        /// <returns></returns>
        public List<Class> GetClassInfo()
        {
            return Db.Set<Class>().Select(u => u).ToList();

        }


        /// <summary>
        /// 查找到用户
        /// </summary>
        /// <param name="userName">姓名</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        public Student GetUserInfo(string userName, string userPwd)
        {
            return Db.Set<Student>().Where(u => u.StudentName == userName && u.StudentPwd == userPwd).SingleOrDefault();
        }

        /// <summary>
        /// 分页的数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示行数</param>
        /// <returns></returns>
        public List<Student> GetAllRoles(int page, int rows)
        {

            IQueryable<Student> role = Db.Set<Student>().OrderBy(a => a.StudentId).Skip((page - 1) * rows).Take(rows);
            List<Student> roleList = role.ToList<Student>();
            if (roleList.Count > 0)
            {
                return roleList;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据班级分页的数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<Student> GetAllRolesByClassId(int page, int rows, int classId)
        {

            IQueryable<Student> role = Db.Set<Student>().Where(u => u.Class.Id == classId).OrderBy(a => a.StudentId).Skip((page - 1) * rows).Take(rows);
            List<Student> roleList = role.ToList<Student>();
            if (roleList.Count > 0)
            {
                return roleList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns>总记录数</returns>
        public int GetTotal()
        {
            IQueryable<Student> user = Db.Set<Student>().Select(m => m);
            List<Student> userList = user.ToList();
            return userList.Count;
        }
        /// <summary>
        /// 根据班级Id获取总页数
        /// </summary>
        /// <param name="ClassId">班级Id</param>
        /// <returns></returns>
        public int GetTotalByClassId(int ClassId)
        {
            IQueryable<Student> user = Db.Set<Student>().Where(u => u.Class.Id == ClassId);
            List<Student> userList = user.ToList();
            return userList.Count;
        }

        /// <summary>
        /// 获取学生所有的考试信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetTestTotal(int id)
        {
            IQueryable<TestPaper> user = Db.Set<TestPaper>().Where(u => u.Student.StudentId == id);
            List<TestPaper> userList = user.ToList();
            return userList.Count;
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
            IQueryable<TestPaper> role=Db.Set<TestPaper>().Where(u=>u.Student.StudentId==studentId).OrderBy(a => a.Id).Skip((page - 1) * rows).Take(rows);
            List<TestPaper> roleList = role.ToList<TestPaper>();
            if (roleList.Count > 0)
            {
                return roleList;
            }
            else
            {
                return null;
            }
        }


    }
}
