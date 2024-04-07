using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models.Entity;
using BlogWeb.Repositories;

namespace BlogWeb.Controllers
{
    public class HobilerimController : Controller
    {
        // GET: Hobilerim
        GenericRepository<TBLHOBILER> repo = new GenericRepository<TBLHOBILER>();

        // panelde verileri listeler
        public ActionResult Index()
        {
            var hobi = repo.list();
            return View(hobi);
        }

        // hobi kısmına veri ekler
        [HttpGet]
        public ActionResult HobilerimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HobilerimEkle(TBLHOBILER hobi)
        {
            repo.TAdd(hobi);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // hobi verilerini güncelleme görevini yapar
        public ActionResult HobilerimGetir(int id)
        {
            var hobi = repo.Find(x => x.ID == id);
            return View(hobi);
        }

        [HttpPost]
        public ActionResult HobilerimGetir(TBLHOBILER hobi)
        {
            var h = repo.Find(x => x.ID == hobi.ID);
            h.HOBBY = hobi.HOBBY;
            repo.TUpdate(h);
            return RedirectToAction("Index");
        }

        // hobi verileri silme görevini yapar
        public ActionResult HobilerimSil(int id)
        {
            var hobi = repo.Find(x => x.ID == id);
            repo.Tdelete(hobi);
            return RedirectToAction("Index");
        }

    }
}