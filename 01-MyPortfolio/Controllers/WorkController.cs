using _01_MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_MyPortfolio.Controllers
{
    public class WorkController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var value = context.Work.ToList();

            return View(value);
        }

        [HttpGet]
        public ActionResult CreateWork()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWork(Work work)
        {
            context.Work.Add(work);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteWork(int id)
        {
            var values = context.Work.Find(id);
            context.Work.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateWork(int id)
        {
            var value = context.Work.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateWork(Work testimonial)
        {
            var value = context.Work.Find(testimonial.WorkId);
            value.Title = testimonial.Title;
            value.Description = testimonial.Description;
            value.ImageUrl = testimonial.ImageUrl;
            value.GithubUrl = testimonial.GithubUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}