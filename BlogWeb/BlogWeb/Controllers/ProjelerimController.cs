using BlogWeb.Models.Entity;
using BlogWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class ProjelerimController : Controller
    {
        // GET: Projelerim
        BlogWebDbEntities db = new BlogWebDbEntities();

        GenericRepository<TBLPROJELER> repo = new GenericRepository<TBLPROJELER>();
       
        // panelde verileri listeler
        public ActionResult Index()
        {
            var proje = repo.list();
            return View(proje);
        }

        // proje kısmına veri ekler
        [HttpGet]
        public ActionResult ProjelerimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjelerimEkle(TBLPROJELER proje)
        {
            repo.TAdd(proje);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // proje verilerini güncelleme görevini yapar
        public ActionResult ProjeGetir(int id)
        {
            var proje = repo.Find(x => x.ID == id);
            return View(proje);
        }

        [HttpPost]
        public ActionResult ProjeGetir(TBLPROJELER proje)
        {
            var p = repo.Find(x => x.ID == proje.ID);
            p.AD = proje.AD;
            p.LİNK = proje.LİNK;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }

        // proje verileri silme görevini yapar
        public ActionResult ProjeSil(int id)
        {
            var proje = repo.Find(x => x.ID == id);
            repo.Tdelete(proje);
            return RedirectToAction("Index");
        }
    }
}