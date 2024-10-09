using _01_MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_MyPortfolio.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult AboutList()
        {
            var value = context.About.ToList();
            
            return View(value);
        }

        public ActionResult DownloadCV()
        {
            // Dosya yolunu kontrol edin
            var filePath = Server.MapPath("~/Content/CvImage/download.jpeg");

            // Eğer dosya yoksa bir hata döndür
            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound("Dosya bulunamadı.");
            }

            var fileName = "download.jpeg";
            var contentType = "CvImage/jpeg";

            // Dosya indirilebilir olarak döndür
            return File(filePath, contentType, fileName);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            context.About.Add(about);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }


        public ActionResult DeleteAbout(int id)
        {
            var values = context.About.Find(id);
            context.About.Remove(values);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.About.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.About.Find(about.AboutId);
            value.Title = about.Title;
            value.Detail = about.Detail;
            value.ImageUrl = about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}