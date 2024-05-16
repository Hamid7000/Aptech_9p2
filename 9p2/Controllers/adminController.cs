using _9p2.Models;
using Microsoft.AspNetCore.Mvc;

namespace _9p2.Controllers
{
    public class adminController : Controller
    {
        private readonly mydb db;
        public adminController(mydb db)
        {
            this.db = db;
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(tbl_login l)
        {
           var check= db.logins.Where(a=>a.login_email== l.login_email && a.login_pass==l.login_pass).FirstOrDefault();
            if (check != null)
            {
                HttpContext.Session.SetString("username",check.login_name.ToString());
                return RedirectToAction("dashboard");
            }
            else
            {
                ViewBag.msg="Login Failed";
            }
            return View();
        }

        public IActionResult dashboard()
        {
            if (HttpContext.Session.GetString("username") ==null)
            {
                return RedirectToAction("login");
            }
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("login");
        }
    }
}
