using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.DAL;
using YKT.Exam.Model;

namespace YKT.Exam.BLL
{
    public class CourseService : BaseService<Course>
    {
        CourseDal courseDal = new CourseDal();
        public override void SetDal()
        {
            Dal = courseDal;
        }
        /// <summary>
        /// 根据Id获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Course GetModelById(int id)
        {
            return courseDal.GetModelById(id);
        }

        /// <summary>
        /// 获取班级列表
        /// </summary>
        /// <returns></returns>
        public List<Course> GetCourseInfo()
        {
            return courseDal.GetCourseInfo();
        }
    }
}
