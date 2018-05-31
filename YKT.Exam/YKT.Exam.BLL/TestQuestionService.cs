using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.DAL;
using YKT.Exam.Model;

namespace YKT.Exam.BLL
{
    public class TestQuestionService:BaseService<TestQuestion>
    {
        TestQuestionDal testQuestionDal = new TestQuestionDal();

        public override void SetDal()
        {
            Dal = testQuestionDal;
        }


        /// <summary>
        /// 根据Id返回实体
        /// </summary>
        /// <param name="id">实体Id</param>
        /// <returns></returns>
        public TestQuestion GetModelById(int id)
        {
            return testQuestionDal.GetModelById(id);
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            return testQuestionDal.GetTotal();
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public List<TestQuestion> GetAllRoles(int page, int rows)
        {
            return testQuestionDal.GetAllRoles(page, rows);
        }
        /// <summary>
        /// 批量删除用户数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteEntities(List<int> list)
        {
            return testQuestionDal.DeleteEntities(list);
        }
    }
}
