using _01_MyPortfolio.Models;
using Microsoft.Win32;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace _01_MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult SkillList(int p=1)
        {
            var values = context.Skill.ToList().ToPagedList(p, 5);

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
        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            var value = context.Skill.Find(skill.SkillId);
            value.Title = skill.Title;
            value.Icon = skill.Icon;
            value.Value = skill.Value;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        //public ActionResult PieChart()
        //{
        //    ArrayList xvalue = new ArrayList();
        //    ArrayList yvalue = new ArrayList();
        //    var data = context.Skill.ToList();


        //    data.ToList().ForEach(x => xvalue.Add(x.Title));
        //    data.ToList().ForEach(y => yvalue.Add(y.Icon));

        //    var graphic = new Chart(width: 1000, height: 500).AddTitle("Yetenekler").AddSeries(chartType: "Pie", name: "Yetenek", xValue: xvalue, yValues: yvalue);

        //    return File(graphic.ToWebImage().GetBytes(), "image/jpeg");

        //}


    }
}