using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            //LİNQ Sorgusu
            List<SelectListItem> degerler=(from i in db.TBLKULUPLER.ToList() 
                                           select new SelectListItem
                                           {
                                               Text=i.KULUPAD,
                                               Value=i.KULUPID.ToString()
                                           }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }


        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p3)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p3.TBLKULUPLER.KULUPID).FirstOrDefault();
            p3.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p3);
            db.SaveChanges(); //değişiklikleri kaydet
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            return View("OgrenciGetir",ogrenci);
        }
        public ActionResult Guncelle(TBLOGRENCILER p)
        {
            var ogr = db.TBLOGRENCILER.Find(p.OGRENCIID);
            ogr.OGAD=p.OGAD;
            ogr.OGSOYAD = p.OGSOYAD;
            ogr.OGFOTO = p.OGFOTO;
            ogr.OGCINSIYET = p.OGCINSIYET;
            ogr.OGKULUP = p.OGKULUP;
            db.SaveChanges();

            return RedirectToAction("Index", "Ogrenci");
        }
    }
}