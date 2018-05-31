using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.Model;

namespace YKT.Exam.DAL
{
   public class TestQuestionDal:BaseDal<TestQuestion>
    {

        /// <summary>
        /// 根据Id返回实体
        /// </summary>
        /// <param name="id">实体Id</param>
        /// <returns></returns>
        public TestQuestion GetModelById(int id)
        {
            return Db.Set<TestQuestion>().Where(u => u.Id == id).FirstOrDefault();
        }


        /// <summary>
        /// 分页的数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示行数</param>
        /// <returns></returns>
        public List<TestQuestion> GetAllRoles(int page, int rows)
        {

            IQueryable<TestQuestion> role = Db.Set<TestQuestion>().OrderBy(a => a.Id).Skip((page - 1) * rows).Take(rows);
            List<TestQuestion> roleList = role.ToList<TestQuestion>();
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
            IQueryable<TestQuestion> TestQuestion = Db.Set<TestQuestion>().Select(m => m);
            List<TestQuestion> TestQuestionList = TestQuestion.ToList();
            return TestQuestionList.Count;
        }
        /// <summary>
        /// 批量删除用户数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteEntities(List<int> list)
        {
            List<TestQuestion> userInfoList = new List<TestQuestion>();
            foreach (int id in list)
            {
                userInfoList.Add(Db.Set<TestQuestion>().Where(u => u.Id == id).SingleOrDefault());
            }
            foreach (TestQuestion item in userInfoList)
            {
                DeleteEntity(item);
                // userInfoList.Remove(item);
            }
            return true;

        }
    }
}
