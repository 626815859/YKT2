using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.DAL;
using YKT.Exam.Model;

namespace YKT.Exam.BLL
{
    public class PaperQuestionService : BaseService<PaperQuestion>
    {
        PaperQuestionDal paperQuestionDal = new PaperQuestionDal();
        public override void SetDal()
        {
            Dal = paperQuestionDal;
        }
        /// <summary>
        /// 根据试卷ID获取该试卷下面的所有试题ID
        /// </summary>
        /// <param name="baseTestPaperId">试卷Id</param>
        /// <returns></returns>
        public List<int> GetTestQueationListByBaseTestPaperId(int baseTestPaperId)
        {
            return paperQuestionDal.GetTestQueationListByBaseTestPaperId(baseTestPaperId);
        }
    }
}
