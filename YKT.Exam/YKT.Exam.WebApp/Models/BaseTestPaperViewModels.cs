using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YKT.Exam.WebApp.Models
{
    public class BaseTestPaperViewModels
    {
        public int ViewBaseTestPaperId{ get; set; }

        public string ViewBaseTestPaperName { get; set; }
        public string ViewBaseTestPaperType { get; set; }
        public DateTime? ViewBaseTestPaperCreateTime { get; set; }

    }
}