using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models.Entity;
using BlogWeb.Repositories;

namespace BlogWeb.Controllers
{
    public class DeneyimController : Controller
    {
        //GET: Deneyim

        DeneyimRepository repo = new DeneyimRepository();

        // panelde verileri listeler
        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }

        // Deneyim kısmına veri ekler
 
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult DeneyimEkle(TBLDENEYIM deneyim)
        {
            repo.TAdd(deneyim);
            return RedirectToAction("Index");
        }

        // Deneyim verilerini güncelleme görevini yapar
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TBLDENEYIM t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(TBLDENEYIM p)
        {
            TBLDENEYIM t = repo.Find(x => x.ID == p.ID);
            t.BASLIK = p.BASLIK;
            t.ALTBASLIK = p.ALTBASLIK;
            t.ACIKLAMA = p.ACIKLAMA;
            t.TARIH = p.TARIH;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

        // deneyim verileri silme görevini yapar
        public ActionResult DeneyimSil(int id)
        {
            TBLDENEYIM t = repo.Find(x => x.ID == id);
            repo.Tdelete(t);
            return RedirectToAction("Index");
        }

    }
}