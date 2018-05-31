using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.Model;

namespace YKT.Exam.DAL
{
   public  class CourseDal:BaseDal<Course>
    {
        /// <summary>
        /// 获取班级信息
        /// </summary>
        /// <returns></returns>
        public List<Course> GetCourseInfo()
        {
            return Db.Set<Course>().Select(u => u).ToList();
        }
        /// <summary>
        /// 根据Id获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Course GetModelById(int id)
        {
            return Db.Set<Course>().Where(u => u.CourseId == id).SingleOrDefault();
        }
    }
}
