using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models.Entity;
using BlogWeb.Repositories;

namespace BlogWeb.Controllers
{
    public class İletisimController : Controller
    {
        // GET: iletisim

        GenericRepository<TBLİLETİSİM> repo=new GenericRepository<TBLİLETİSİM>();
        public ActionResult Index()
        {
            var mesajlar = repo.list();
            return View(mesajlar);
        }

        // iletisim verilerini getirme görevini yapar
        public ActionResult iletisimGetir(int id)
        {
            var iletisim = repo.Find(x => x.ID == id);
            return View(iletisim);
        }

        [HttpPost]
        public ActionResult iletisimGetir(TBLİLETİSİM i)
        {
            var iletisim = repo.Find(x => x.ID == i.ID);
            iletisim.ID = i.ID;
            iletisim.AdveSoyad = i.AdveSoyad;
            iletisim.Mail = i.Mail;
            iletisim.Konu = i.Konu;
            iletisim.Mesaj = i.Mesaj;
            iletisim.Tarih= i.Tarih;
            repo.TUpdate(iletisim);
            return View();
        }


        // iletisim verileri silme görevini yapar
        public ActionResult iletisimSil(int id)
        {
            var iletisim = repo.Find(x => x.ID == id);
            repo.Tdelete(iletisim);
            return RedirectToAction("Index");
        }

    }
}