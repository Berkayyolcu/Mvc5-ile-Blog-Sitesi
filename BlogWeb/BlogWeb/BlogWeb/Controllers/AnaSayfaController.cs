using BlogWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        BlogWebDbEntities db = new BlogWebDbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var deger1 = db.TBLDENEYIM.Count();
            var deger2 = db.TBLEGITIM.Count();
            var deger3 = db.TBLYETENEKLER.Count();
            var deger4 = db.TBLHOBILER.Count();
            var deger5 = db.TBLPROJELER.Count();
            var deger6 = db.TBLSERTIFIKALAR.Count();

            ViewBag.deneyim = deger1;
            ViewBag.egitim = deger2;
            ViewBag.yetenek = deger3;
            ViewBag.hobi = deger4;
            ViewBag.proje = deger5;
            ViewBag.sertifika = deger6;

            var user = (string)Session["User"];
            //var d1 = db.TBLADMİN.Where(x => x.User == user).Select(y => y.User).FirstOrDefault();
            ViewBag.d1 = user;

            return View();
        }
        
    }
   
}