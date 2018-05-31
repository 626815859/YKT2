using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.Model;

namespace YKT.Exam.DAL
{
  public  class ClassDal:BaseDal<Class>
    {
        /// <summary>
        /// 根据Id获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Class GetModelById(int id)
        {
            return Db.Set<Class>().Where(u => u.Id == id).SingleOrDefault();
        }
    }
}
