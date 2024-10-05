using _01_MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_MyPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            List<SelectListItem> values = (from x in context.Category.ToList()
                                         select new SelectListItem
                                         {
                                             Text=x.CategoryName, //kullanıcıya gözüken kısım
                                             Value=x.CategoryId.ToString() //arka planda çalışan kısım
                                         }).ToList();
            ViewBag.v = values;                             
            return View();
        }

        [HttpPost]
        public ActionResult Index(Message message)
        {
            message.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.IsRead = false;
            context.Message.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        
        public PartialViewResult PartialHeader()
        {
            ViewBag.Title=context.About.Select(a => a.Title).FirstOrDefault();
            ViewBag.Detail=context.About.Select(a => a.Detail).FirstOrDefault();
            ViewBag.ImageUrl=context.About.Select(a => a.ImageUrl).FirstOrDefault();

            ViewBag.Address=context.Profile.Select(a => a.Address).FirstOrDefault();
            ViewBag.Mail=context.Profile.Select(a => a.Email).FirstOrDefault();
            ViewBag.Phone=context.Profile.Select(a => a.PhoneNumber).FirstOrDefault();
            ViewBag.Github=context.Profile.Select(a => a.Github).FirstOrDefault();

            return PartialView();
        }
        
        public PartialViewResult PartialAbout()
        {
            ViewBag.Title=context.Profile.Select(a => a.Title).FirstOrDefault();
            ViewBag.Description=context.Profile.Select(a => a.Description).FirstOrDefault();
            ViewBag.Phone=context.Profile.Select(a => a.PhoneNumber).FirstOrDefault();
            ViewBag.ImageUrl=context.Profile.Select(a => a.ImageUrl).FirstOrDefault();

            return PartialView();
        }
        
        public PartialViewResult PartialEducation()
        {
            var values = context.Education.ToList();

            return PartialView(values);
        }
        
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialSkill()
        {
            var values = context.Skill.ToList();

            return PartialView(values);
        }

        public PartialViewResult PartialSocialMedia()
        {
            var values = context.SocialMedia.Where(x => x.Status==true).ToList();
            return PartialView(values);
        }


    }
}