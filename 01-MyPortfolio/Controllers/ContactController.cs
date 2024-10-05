using _01_MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public PartialViewResult PartialContactSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialContactAdress()
        {
            ViewBag.Description=context.Profile.Select(a=>a.Description).FirstOrDefault();
            ViewBag.Address=context.Profile.Select(a=>a.Address).FirstOrDefault();
            ViewBag.Email=context.Profile.Select(a=>a.Email).FirstOrDefault();
            ViewBag.Phone=context.Profile.Select(a=>a.PhoneNumber).FirstOrDefault();

            return PartialView();
        } 
        public PartialViewResult PartialContactLocation()
        {
            ViewBag.mapLocation=context.Profile.Select(a=>a.MapLocation).FirstOrDefault();

            return PartialView();
        }
    }
}