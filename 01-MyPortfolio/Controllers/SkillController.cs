using _01_MyPortfolio.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult SkillList()
        {
            var values =context.Skill.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(Skill skill) //burada Skill tablosundan skill isminde parametre aldık
        {
            context.Skill.Add(skill);
            context.SaveChanges(); //ekleme işlemini veritabanına kaydet
            return RedirectToAction("SkillList");
        }

        
        public ActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public ActionResult EditSkill()
        {
            return View();
        }


    }
}