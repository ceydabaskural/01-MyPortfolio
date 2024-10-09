using _01_MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_MyPortfolio.Controllers
{
    public class GraphicController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public PartialViewResult PartialChartSkill()
        {
            var values = context.Skill.ToList();
            return PartialView("PartialChartSkill", values);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}