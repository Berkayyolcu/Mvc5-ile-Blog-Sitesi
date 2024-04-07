using BlogWeb.Models.Entity;
using BlogWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class MetaController : Controller
    {
        // GET: Meta

        GenericRepository<TBLMETATAG> repo = new GenericRepository<TBLMETATAG>();

        BlogWebDbEntities db = new BlogWebDbEntities();


        // panelde verileri listeler
        public ActionResult Index(TBLMETATAG tag)
        {
            
            var meta = repo.list();
            return View(meta);

        }

        // meta kısmına veri ekler
        [HttpGet]
        public ActionResult MetaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MetaEkle(TBLMETATAG meta)
        {
            repo.TAdd(meta);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // meta verilerini güncelleme görevini yapar
        public ActionResult MetaGetir(int id)
        {
            var meta = repo.Find(x => x.ID == id);
            return View(meta);
        }

        [HttpPost]
        public ActionResult MetaGetir(TBLMETATAG meta)
        {
            var m = repo.Find(x => x.ID == meta.ID);
            m.Abstract = meta.Abstract;
            m.Author = meta.Author;
            m.Description = meta.Description;
            m.Keywords = meta.Keywords;
            m.Title = meta.Title;
            repo.TUpdate(m);
            return RedirectToAction("Index");
        }

        // meta verileri silme görevini yapar
        public ActionResult MetaSil(int id)
        {
            var meta = repo.Find(x => x.ID == id);
            repo.Tdelete(meta);
            return RedirectToAction("Index");
        }
    }
}