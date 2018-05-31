using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YKT.Exam.Model;

namespace YKT.Exam.WebApp.Models
{
    public class ClassCourseViewModels
    {
        public List<Class> ClassList { get; set; }
        public List<Course> CourseList { get; set; }
    }
}