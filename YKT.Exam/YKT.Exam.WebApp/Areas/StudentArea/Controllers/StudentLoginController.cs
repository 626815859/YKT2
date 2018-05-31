using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YKT.Exam.BLL;
using YKT.Exam.Common;
using YKT.Exam.Model;

namespace YKT.Exam.WebApp.Areas.StudentArea.Controllers
{
    public class StudentLoginController : Controller
    {
        StudentService SrudentService = new StudentService();
        // GET: Student/StudentLogin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginIndex()
        {
            return View();
        }

        public ActionResult StudentLogin()
        {

            string validateCode = Session["code"] == null ? string.Empty :    //string.Empty为了健壮性，如果不转换，则Null.Tostring（）会报错
                Session["code"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误");
            }
            Session["code"] = null;
            string txtCode = Request["vCode"];
            //判断，如果系统的验证码与用户输入的验证码不一致，则提示，StringComparison.InvariantCultureIgnoreCase忽略大小写
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            //  UserInfoService userInfoService = new UserInfoService();
            Student userInfo = SrudentService.GetUserInfo(userName, userPwd);
            if (userInfo != null)
            {
                Session["userInfo"] = userInfo;
                return Content("ok:登录成功!");
            }
            else
            {
                return Content("no:登录失败！");
            }
        }


        //调用封装验证码的类
        public ActionResult ShowValidateCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);//获取验证码长度.
            Session["code"] = code;//存入与用户输入进行校验
            byte[] buffer = validateCode.CreateValidateGraphic(code);  //创建图片
            return File(buffer, "image/jpeg");
        }
    }
}