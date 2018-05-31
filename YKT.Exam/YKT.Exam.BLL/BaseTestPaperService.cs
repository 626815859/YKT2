using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.DAL;
using YKT.Exam.Model;

namespace YKT.Exam.BLL
{
  public  class BaseTestPaperService : BaseService<BaseTestPaper>
    {
        BaseTestPaperDal baseTestPaperDal = new BaseTestPaperDal();
        public override void SetDal()
        {
            Dal = baseTestPaperDal;
        }

        /// <summary>
        /// 根据Id获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseTestPaper GetModelById(int id)
        {
            return baseTestPaperDal.GetModelById(id);
        }
        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            return baseTestPaperDal.GetTotal();
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public List<BaseTestPaper> GetAllRoles(int page, int rows)
        {
            return baseTestPaperDal.GetAllRoles(page, rows);
        }
    }
}
