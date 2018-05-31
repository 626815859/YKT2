using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.Model;

namespace YKT.Exam.DAL
{
   public class PaperQuestionDal:BaseDal<PaperQuestion>
    {
        /// <summary>
        /// 根据试卷ID获取该试卷下面的所有试题ID
        /// </summary>
        /// <param name="baseTestPaperId">试卷Id</param>
        /// <returns></returns>
        public List<int> GetTestQueationListByBaseTestPaperId(int baseTestPaperId)
        {
           return Db.Set<PaperQuestion>().Where(u => u.BaseTestPaper.Id == baseTestPaperId).Select(u => u.Id).ToList();
        }


    }
}
