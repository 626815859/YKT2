using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YKT.Exam.WebApp.Models
{
    public class TestQuestionViewModels
    {
        public int ViewTestQuestionId { get; set; }

        public string ViewTestQuestionType { get; set; }
        public string ViewTestQuestionName { get; set; }
      //  public string ViewTestQuestionQuestion { get; set; }
        public Nullable<int> ViewTestQuestionGrade { get; set; }
        public string ViewTestQuestionResult { get; set; }
    }
}