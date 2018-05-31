using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.Model;

namespace YKT.Exam.DAL
{
    public class BaseTestPaperDal:BaseDal<BaseTestPaper>
    {


        /// <summary>
        /// 根据Id获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseTestPaper GetModelById(int id)
        {
            return Db.Set<BaseTestPaper>().Where(u => u.Id == id).SingleOrDefault();
        }
        /// <summary>
        /// 分页的数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示行数</param>
        /// <returns></returns>
        public List<BaseTestPaper> GetAllRoles(int page, int rows)
        {

            IQueryable<BaseTestPaper> role = Db.Set<BaseTestPaper>().OrderBy(a => a.Id).Skip((page - 1) * rows).Take(rows);
            List<BaseTestPaper> roleList = role.ToList<BaseTestPaper>();
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
            IQueryable<BaseTestPaper> BaseTestPaper = Db.Set<BaseTestPaper>().Select(m => m);
            List<BaseTestPaper> BaseTestPaperList = BaseTestPaper.ToList();
            return BaseTestPaperList.Count;
        }
    }
}
