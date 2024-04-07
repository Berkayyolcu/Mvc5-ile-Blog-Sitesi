using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models.Entity;
using BlogWeb.Repositories;

namespace BlogWeb.Controllers
{
    public class EğitimController : Controller
    {
        // GET: Eğitim
        GenericRepository<TBLEGITIM> repo = new GenericRepository<TBLEGITIM>();

        // panelde verileri listeler
        public ActionResult Index()
        {
            var egitim = repo.list();
            return View(egitim);
        }

        // egitim kısmına veri ekler
        [HttpGet]
        public ActionResult EğitimEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EğitimEkle(TBLEGITIM egitim)
        {
            repo.TAdd(egitim);
            return RedirectToAction("Index");
        }
     
        [HttpGet]
        // egitim verilerini güncelleme görevini yapar
        public ActionResult EğitimGetir(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EğitimGetir(TBLEGITIM egitim)
        {
            var e = repo.Find(x => x.ID == egitim.ID);
            e.BASLIK = egitim.BASLIK;
            e.ALTBASLIK = egitim.ALTBASLIK;
            e.ACIKLAMA = egitim.ACIKLAMA;
            e.NOT = egitim.NOT;
            e.TARIH = egitim.TARIH;
            repo.TUpdate(e);
            return RedirectToAction("Index");
        }

        // egitim verileri silme görevini yapar
        public ActionResult EğitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.Tdelete(egitim);
            return RedirectToAction("Index");
        }

    }
}