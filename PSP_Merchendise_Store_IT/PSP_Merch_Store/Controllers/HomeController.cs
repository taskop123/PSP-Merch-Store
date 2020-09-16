using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSP_Merch_Store.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PSP_Merch_Store.Models.ApplicationDbContext _db = new PSP_Merch_Store.Models.ApplicationDbContext();
            var allItems = _db.Products.ToList();
            var AllNames = new List<String>();
            foreach (var item in allItems)
            {
                AllNames.Add(item.NameOfProduct);
            }
            ViewBag.AllNames = JsonConvert.SerializeObject(AllNames);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "За нас";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}