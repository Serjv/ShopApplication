using ShopApplication.DAL;
using ShopApplication.Models;
using ShopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopApplication.Controllers
{
    public class HomeController : Controller
    {

        ShopsContext db = new ShopsContext();
        List<string> sho = new List<string>();
        List<string> cons = new List<string>();

        public ActionResult Index()
        {
            var result = from ic in db.Interconnections
                             join shops in db.Shops on ic.ShopID equals shops.ShopID
                             join con in db.Consultants on ic.ConsultantID equals con.ConsultantID
                         group ic by new { ic.ID,shops.ShopName,shops.Address,con.ConsultantName,con.ConsultantSurname,ic.Date } into g
                         orderby g.Key.ID
                         select new ShopsTotal
                         {
                             ID = g.Key.ID,
                             ShopName = g.Key.ShopName,
                             ConsultantName = g.Key.ConsultantName+" "+g.Key.ConsultantSurname,
                             Address = g.Key.Address,
                             Date = g.Key.Date
                         };



            return View(result);
        }

        public ActionResult NewShop()
        {
            return PartialView();
        }

        [HttpPost]
        
        public ActionResult NewShop(Shops shop)
        {

                db.Shops.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index");

        }

        public ActionResult NewConsultant()
        {
            return PartialView();
        }

        [HttpPost]
        
        public ActionResult NewConsultant(Consultants consultant)
        {
            var sho = (from shop in db.Shops
                       select shop.ShopName).ToList();
            var cons = (from con in db.Consultants
                        select con.ConsultantSurname).ToList();
            db.Consultants.Add(consultant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "")]
        public ActionResult NConsultant()
        {
            sho = (from shop in db.Shops
                         select shop.ShopName).ToList();
            cons = (from con in db.Consultants
                        select con.ConsultantSurname).ToList();
            ViewBag.Shops = new SelectList(sho);
            ViewBag.Consultants = new SelectList(cons);
            
            return PartialView();
        }

        [HttpPost]
        
        public ActionResult NConsultant(string Shops, string Consultants)
        {
            var shopid = (from shop in db.Shops where shop.ShopName == Shops select shop.ShopID).FirstOrDefault();
            var consultantid = (from con in db.Consultants where con.ConsultantSurname == Consultants select con.ConsultantID).FirstOrDefault();
            Interconnections interconnection = new Interconnections { Date= DateTime.Now,ShopID = shopid, ConsultantID = consultantid };
            db.Interconnections.Add(interconnection);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}