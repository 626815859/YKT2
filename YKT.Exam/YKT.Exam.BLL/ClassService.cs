using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.DAL;
using YKT.Exam.Model;

namespace YKT.Exam.BLL
{
    public class ClassService : BaseService<Class>
    {
        ClassDal classDal = new ClassDal();
        public override void SetDal()
        {
            Dal = classDal;
        }
        /// <summary>
        /// 根据Id获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Class GetModelById(int id)
        {
            return classDal.GetModelById(id);
        }
    }
}
