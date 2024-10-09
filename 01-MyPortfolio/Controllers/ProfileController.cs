using _01_MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_MyPortfolio.Controllers
{
    public class ProfileController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var value = context.Profile.ToList();

            return View(value);
        }


        [HttpGet]
        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(Profile profile)
        {
            context.Profile.Add(profile);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteProfile(int id)
        {
            var values = context.Profile.Find(id);
            context.Profile.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var value = context.Profile.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProfile(Profile profile)
        {
            var value = context.Profile.Find(profile.ProfileId);
            value.Title = profile.Title;
            value.Description = profile.Description;
            value.Address = profile.Address;
            value.Email = profile.Email;
            value.PhoneNumber = profile.PhoneNumber;
            value.Github = profile.Github;
            value.ImageUrl = profile.ImageUrl;
            value.MapLocation = profile.MapLocation;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}