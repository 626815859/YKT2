﻿using System.Web.Mvc;

namespace YKT.Exam.WebApp.Areas.TeacherArea
{
    public class TeacherAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TeacherArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TeacherArea_default",
                "TeacherArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}