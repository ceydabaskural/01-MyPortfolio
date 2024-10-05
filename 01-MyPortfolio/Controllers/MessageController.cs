using _01_MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
       MyPortfolioDbEntities context = new MyPortfolioDbEntities();

        public ActionResult Inbox()
        {
            var values=context.Message.ToList();
            return View(values);
        }

        //Buradaki parametre mutlaka 'id' şeklinde yazılmalı.Sebebi ise App_Start klasöründe bulunan RouteConfig.cs isimli dosyada bulunan default yapılandırmada 'id' şeklinde yazılı olarak verilmiş. Eğer biz burada id parametremizin adını MessageId şeklinde yazarsak gidip RouteConfig.cs dosyasında da MessageId olarak değiştirmeliyiz
        public ActionResult MessageDetails(int id)
        {
            //MessageId si bizim parametre olarak verdiğimiz id ye eşit olan tek veriyi döndür demek:
            var value=context.Message.Where(x=>x.MessageId==id).FirstOrDefault();
            return View(value);
        }

        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var value = context.Message.Where(x => x.MessageId == id).FirstOrDefault();
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        } 
        
        public ActionResult MessageStatusChangeToFalse(int id)
        {
            var value = context.Message.Where(x => x.MessageId == id).FirstOrDefault();
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        } 
    }
}