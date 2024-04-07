using BlogWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        BlogWebDbEntities db = new BlogWebDbEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TBLADMİN u)
        {
            var userdb = db.TBLADMİN.FirstOrDefault(x => x.User == u.User && x.Password == u.Password);
            if (userdb != null) {
                FormsAuthentication.SetAuthCookie(u.User, false);
                Session["User"] = userdb.User.ToString();
                return RedirectToAction("Index","AnaSayfa");
            }
            else
            {
                return View();
            }
           
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }


    }
}