using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YKT.Exam.WebApp.Models
{
    public class addTestQuestionViewModel
    {
        public string ViewTestQuestionType { get; set; }
        public string ViewTestQuestionName { get; set; }
        public string optionA { get; set; }
        public string optionB { get; set; }
        public string optionC { get; set; }
        public string optionD { get; set; }
        public string ViewTestQuestionResult { get; set; }
        public Nullable<int> ViewTestQuestionGrade { get; set; }
    }
}