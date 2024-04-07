using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models.Entity;
using BlogWeb.Repositories;
namespace BlogWeb.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TBLADMİN> repo =new GenericRepository<TBLADMİN> ();
        public ActionResult Index()
        {
            var liste = repo.list();
            return View(liste);
        }

        // Deneyim kısmına veri ekler
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(TBLADMİN admin)
        {
            repo.TAdd(admin);
            return RedirectToAction("Index");
        }

        // Admin verilerini güncelleme görevini yapar
        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            TBLADMİN admin = repo.Find(x => x.ID == id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult AdminGetir(TBLADMİN a)
        {
            TBLADMİN admin = repo.Find(x => x.ID == a.ID);
            admin.User = a.User;
            admin.Password = a.Password;
            repo.TUpdate(admin);
            return RedirectToAction("Index");
        }

        // Admin verileri silme görevini yapar
        public ActionResult AdminSil(int id)
        {
            TBLADMİN t = repo.Find(x => x.ID == id);
            repo.Tdelete(t);
            return RedirectToAction("Index");
        }

    }
}