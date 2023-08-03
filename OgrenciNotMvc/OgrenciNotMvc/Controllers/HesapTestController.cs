using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(double sayi1 = 0, double sayi2 = 0)
        {
            // Bu sayılar üzerinde işlem yapmadan önce verilerin boş olup olmadığını kontrol edelim.
            if (ModelState.IsValid)
            {
                double toplam = sayi1 + sayi2;
                double çıkarma = sayi1 - sayi2;
                double çarpma = sayi1 * sayi2;
                double bölme = sayi1 / sayi2;

                // Controller tarafındaki değerleri view tarafına taşır
                ViewBag.tpl = toplam;
                ViewBag.ckr = çıkarma;
                ViewBag.crp = çarpma;
                ViewBag.bol = bölme;
                ViewBag.sayi1 = sayi1;
                ViewBag.sayi2 = sayi2;
            }

            return View();
        }

        // POST: HesapTest
        [HttpPost]
        public ActionResult Index(double sayi1, double sayi2, string islem)
        {
            double sonuc = 0;
            switch (islem)
            {
                case "topla":
                    sonuc = sayi1 + sayi2;
                    break;
                case "cikar":
                    sonuc = sayi1 - sayi2;
                    break;
                case "carp":
                    sonuc = sayi1 * sayi2;
                    break;
                case "bol":
                    sonuc = sayi1 / sayi2;
                    break;
            }

            ViewBag.islemSonucu = sonuc;
            ViewBag.sayi1 = sayi1;
            ViewBag.sayi2 = sayi2;

            return View();
        }

       
    }
}

