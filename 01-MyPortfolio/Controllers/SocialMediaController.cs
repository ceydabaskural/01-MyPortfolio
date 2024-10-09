using _01_MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var value = context.SocialMedia.ToList();
            return View(value);
        }

        public ActionResult SocialMediaStatusChangeToTrue(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SocialMediaStatusChangeToFalse(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            context.SocialMedia.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value=context.SocialMedia.Find(id);

            return View(value);
        }
        
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia media)
        {
            var value = context.SocialMedia.Find(media.SocialMediaId);
            value.Title=media.Title;
            value.Icon = media.Icon;
            value.Status = media.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia media)
        {
            context.SocialMedia.Add(media);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}