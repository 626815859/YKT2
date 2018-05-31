using System.Web.Mvc;

namespace YKT.Exam.WebApp.Areas.StudentArea
{
    public class StudentAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "StudentArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "StudentArea_default",
                "StudentArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}