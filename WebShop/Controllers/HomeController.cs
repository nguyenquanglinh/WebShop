using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        MyDBContext con = new MyDBContext();
        public ActionResult Index()
        {
            var list = con.Products.Take(8).ToList();
            var listCategory = con.Category.Take(8).ToList();
            ViewBag.listCategory = listCategory;
            return View(list);
        }

        public ActionResult About()
        {
            var list = con.Abouts.Where(x => x.ID_About==1).FirstOrDefault();
            return View(list);
        }

        public ActionResult Contact()
        {
            var list = con.Contacts.Where(x => x.ID_Contact == 1).FirstOrDefault();
            return View(list);
        }
        public ActionResult New()
        {

            return View();
        }
    }
}