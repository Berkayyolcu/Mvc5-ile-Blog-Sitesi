using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models.Entity;

namespace BlogWeb.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        BlogWebDbEntities db = new BlogWebDbEntities();

        // siteye verileri listeler
        public ActionResult Index()
        {
            var degerler = db.TBLHAKKIMDA.ToList();
            return View(degerler);
        }
 
        ////hakkımda kısmına veri ekler
        //[HttpGet]
        //public ActionResult HakkımdaEkle()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult HakkımdaEkle(TBLHAKKIMDA hakkımda)
        //{

        //    if (Request.Files.Count > 0)
        //    {
        //        string file = Path.GetFileName(Request.Files[0].FileName);
        //        string uzanti = Path.GetExtension(Request.Files[0].FileName);
        //        string yol = "/blog_sitem/img/" + file + uzanti;
        //        Request.Files[0].SaveAs(Server.MapPath(yol));
        //        hakkımda.Resim = "/blog_sitem/img/" + file + uzanti;

        //    }

        //    db.TBLHAKKIMDA.Add(hakkımda);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        // hakkımda verilerini güncelleme görevini yapar
        public ActionResult HakkımdaGetir(int id)
        {
            var hk = db.TBLHAKKIMDA.Find(id);
            return View(hk);
        }

        public ActionResult HakkımdaGuncelle(TBLHAKKIMDA hakkımda)
        {
            var hk = db.TBLHAKKIMDA.Find(hakkımda.ID);

            hk.AD = hakkımda.AD;
            hk.SOYAD = hakkımda.SOYAD;
            hk.ADRES = hakkımda.ADRES;
            hk.MAIL = hakkımda.MAIL;
            hk.TELEFON = hakkımda.TELEFON;
            hk.KISANOT = hakkımda.KISANOT;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //// hakkımda verileri silme görevini yapar
        //public ActionResult HakkımdaSil(int id)
        //{
        //    var hakkımda = db.TBLHAKKIMDA.Find(id);
        //    db.TBLHAKKIMDA.Remove(hakkımda);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}