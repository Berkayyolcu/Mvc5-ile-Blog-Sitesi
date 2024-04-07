using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models.Entity;
using BlogWeb.Repositories;

namespace BlogWeb.Controllers
{
    public class SertifikalarımController : Controller
    {
        // GET: Sertifikalarım
        BlogWebDbEntities db = new BlogWebDbEntities();

        GenericRepository<TBLSERTIFIKALAR> repo = new GenericRepository<TBLSERTIFIKALAR>();

        // panelde verileri listeler
        public ActionResult Index()
        {
            var sertifika = repo.list();
            return View(sertifika);
        }

        // sertifika kısmına veri ekler
        [HttpGet]
        public ActionResult SertifikalarımEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SertifikalarımEkle(TBLSERTIFIKALAR sertifika)
        {
            repo.TAdd(sertifika);
            return RedirectToAction("Index");
        }


        [HttpGet]
        // sertifika verilerini güncelleme görevini yapar
        public ActionResult SertifikalarımGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikalarımGetir(TBLSERTIFIKALAR sertifika)
        {
            var s = repo.Find(x => x.ID == sertifika.ID);
            s.SERTIFIKALARIM = sertifika.SERTIFIKALARIM;
            s.KURUM = sertifika.KURUM;
            s.EĞİTMEN = sertifika.EĞİTMEN;
            s.TARİH = sertifika.TARİH;
            s.SÜRE = sertifika.SÜRE;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }

        // sertifika verileri silme görevini yapar
        public ActionResult SertifikalarımSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.Tdelete(sertifika);
            return RedirectToAction("Index");
        }


    }
}