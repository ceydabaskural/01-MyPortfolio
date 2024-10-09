using _01_MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_MyPortfolio.Controllers
{
    public class AdminController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        } 
        public PartialViewResult PartialSideBar()
        {
            ViewBag.ImageUrl = context.About.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
    }
}