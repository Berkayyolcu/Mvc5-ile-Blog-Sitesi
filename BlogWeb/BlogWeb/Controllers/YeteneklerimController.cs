using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models.Entity;
using BlogWeb.Repositories; 

namespace BlogWeb.Controllers
{
    public class YeteneklerimController : Controller
    {
        // GET: Yeteneklerim

        GenericRepository<TBLYETENEKLER> repo = new GenericRepository<TBLYETENEKLER>();

        // panelde verileri listeler
        public ActionResult Index()
        {
            var yetenek = repo.list();
            return View(yetenek);
        }

        // yetenek kısmına veri ekler
        [HttpGet]
        public ActionResult YeteneklerimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeteneklerimEkle(TBLYETENEKLER yetenek)
        {
            repo.TAdd(yetenek);
            return RedirectToAction("Index");
        }


        [HttpGet]
        // yetenek verilerini güncelleme görevini yapar
        public ActionResult YeteneklerimGetir(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YeteneklerimGetir(TBLYETENEKLER p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            t.YETENEKLER = p.YETENEKLER;
            t.ORAN = p.ORAN;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }


        // yetenek verileri silme görevini yapar
        public ActionResult YeteneklerimSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.Tdelete(yetenek);
            return RedirectToAction("Index");
        }


    }
}