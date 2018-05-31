using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.DAL;
using YKT.Exam.Model;

namespace YKT.Exam.BLL
{
    public class TestPaperService : BaseService<TestPaper>
    {
        TestPaperDal testPaperDal = new TestPaperDal();
        public override void SetDal()
        {
            Dal = testPaperDal;
        }
    }
}
