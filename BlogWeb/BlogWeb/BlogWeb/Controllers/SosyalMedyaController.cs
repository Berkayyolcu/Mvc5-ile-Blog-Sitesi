using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models.Entity;
using BlogWeb.Repositories;

namespace BlogWeb.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TBLSOSYALMEDYA> repo = new GenericRepository<TBLSOSYALMEDYA>();
        public ActionResult Index()
        {
            var sosyalmedya = repo.list();
            return View(sosyalmedya);
        }

        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SosyalMedyaEkle(TBLSOSYALMEDYA p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // sosyal medya verilerini güncelleme görevini yapar
        public ActionResult SosyalMedyaGetir(int id)
        {
            var socialmedia = repo.Find(x => x.ID == id);
            return View(socialmedia);
        }

        [HttpPost]
        public ActionResult SosyalMedyaGetir(TBLSOSYALMEDYA p)
        {
            var s = repo.Find(x => x.ID == p.ID);
            s.AD=p.AD;
            s.LİNK = p.LİNK;
            s.İKON = p.İKON;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }

        // sosyal medya verilerini silme görevini yapar
        public ActionResult SosyalMedyaSil(int id)
        {
            var  socialmedia= repo.Find(x => x.ID == id);
            socialmedia.DURUM = false;
            repo.TUpdate(socialmedia);
            return RedirectToAction("Index");
        }


    }
}