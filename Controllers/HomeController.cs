using CRUDApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApp.Controllers
{
    public class HomeController : Controller
    {
        // GET : Home
        List<kayitModel> kayitListe = new List<kayitModel> { 
            new kayitModel() {kayId= 1, adsoyad="Erhan", yas=25, adres="İstanbul"},
            new kayitModel() {kayId= 2, adsoyad="Ali", yas=26, adres="Ankara"},
            new kayitModel() {kayId= 3, adsoyad="Veli", yas=27, adres="İzmir"},
            new kayitModel() {kayId= 4, adsoyad="Ahmet", yas=28, adres="Rize"},
            new kayitModel() {kayId= 5, adsoyad="Mehmet", yas=29, adres="Isparta"},
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kayitlar()
        {
            return View(kayitListe);
        }

        public IActionResult Detay(int ? id)
        {
            var kayit = kayitListe.Where (k => k.kayId ==id).SingleOrDefault();
            if (kayit !=null)
            {
                return View(kayit);
            }
            else
            {
                return RedirectToAction("Kayitlar");
            }
           
        }

        public ActionResult Hesapla()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Hesapla(IFormCollection frm)
        {
            double vNot = Convert.ToDouble(frm["vNot"].ToString());
            double uNot = Convert.ToDouble(frm["uNot"].ToString());
            double fNot = Convert.ToDouble(frm["fNot"].ToString());

            double ort=(vNot*0.3)+(uNot*0.1)+(fNot*0.6);

            if(ort<60)
            {
                ViewBag.ortalama= ort.ToString();
                ViewBag.sonuc = "Kaldı";
                ViewBag.cl = "alert alert-danger";
            }
            else
            {
                ViewBag.ortalama = ort.ToString();
                ViewBag.sonuc = "Geçti";
                ViewBag.cl = "alert alert-success";

            }
            return View();
        }
    }
}
