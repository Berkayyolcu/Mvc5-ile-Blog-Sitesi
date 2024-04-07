using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models.Entity;


namespace BlogWeb.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        // veri tabanına baglanma ve  db degisken ile veri cekme
        BlogWebDbEntities db = new BlogWebDbEntities();

        public ActionResult Index()
        {
            var hakkımda = db.TBLHAKKIMDA.ToList();
            return View(hakkımda);
        }

        public PartialViewResult Meta()
        {
            var meta = db.TBLMETATAG.ToList();
            return PartialView(meta);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TBLSOSYALMEDYA.Where(x => x.DURUM==true).ToList();
            return PartialView(sosyalmedya);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TBLDENEYIM.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitimlerim()
        {
            var egitim = db.TBLEGITIM.ToList();
            return PartialView(egitim);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenek = db.TBLYETENEKLER.ToList();
            return PartialView(yetenek);
        }

        public PartialViewResult Hobilerim()
        {
            var hobi = db.TBLHOBILER.ToList();
            return PartialView(hobi);
        }

        public PartialViewResult Projelerim()
        {
            var proje = db.TBLPROJELER.ToList();
            return PartialView(proje);
        }

        public PartialViewResult Sertifikalarım()
        {
            var sertifika = db.TBLSERTIFIKALAR.ToList();
            return PartialView(sertifika);
        }

        [HttpGet]
        public PartialViewResult iletisim()
        {         
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult iletisim(TBLİLETİSİM t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortTimeString());
            db.TBLİLETİSİM.Add(t);
            db.SaveChanges();
            return PartialView();
        }


    }
}