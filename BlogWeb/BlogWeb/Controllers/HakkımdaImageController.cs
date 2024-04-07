
using BlogWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class HakkımdaImageController : Controller
    {
        // GET: HakkımdaImage

        BlogWebDbEntities db = new BlogWebDbEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAKKIMDA.ToList();
            return View(degerler);
        }

        // HakkımdaImage güncelleme görevini yapar
        public ActionResult HakkımdaImageGetir(int id)
        {
            var hk = db.TBLHAKKIMDA.Find(id);
            return View(hk);
        }

        public ActionResult HakkımdaImageGuncelle(TBLHAKKIMDA hakkımda)
        {
            var hk = db.TBLHAKKIMDA.Find(hakkımda.ID);

            if (Request.Files.Count > 0)
            {
                string file = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/blog_sitem/img/" + file + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                hakkımda.Resim = "/blog_sitem/img/" + file + uzanti;
            }
            hk.Resim = hakkımda.Resim;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // hakkımda Image silme görevini yapar
        public ActionResult HakkımdaSil(int id)
        {
            var hakkımda = db.TBLHAKKIMDA.Find(id);
            db.TBLHAKKIMDA.Remove(hakkımda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}