using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    public class HangSXController : Controller
    {
        // GET: Admin/HangSX
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index(string mess)
        {
            using (var con = new MyDBContext())
            {
                ViewBag.mes = mess;
                var model = con.Category.OrderByDescending(p => p.ID_Trademark).ToList();
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var con = new MyDBContext())
            {
                var model = con.Products.Find(id);
                return View(model);
            }
        }

        // GET: Admin/ProductAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            var con = new MyDBContext();
            var check = con.Products.FirstOrDefault(o => o.ID_Trademark == id);
            if (check != null)
            {
                return Redirect("/Admin/HangSX?mess=2");
            }
            else
            {
                var obj = con.Category.FirstOrDefault(x => x.ID_Trademark == id);
                con.Category.Remove(obj);
                con.SaveChanges();
                return Redirect("/Admin/HangSX?mess=1");
            }
        }
        //Add Product

        public ActionResult Add(FormCollection form)
        {
            var con = new MyDBContext();
            Trademark product = new Trademark();
            product.Name = form["name"];
            con.Category.Add(product);
            con.SaveChanges();
            return Redirect("/Admin/HangSX?mess=1");
        }
        //Update
        public ActionResult Update(FormCollection form)
        {
            var con = new MyDBContext();
            var id = Int32.Parse(form["id"]);
            Trademark product = con.Category.FirstOrDefault(p => p.ID_Trademark == id);
            product.Name = form["name"];
            con.SaveChanges();
            return Redirect("/Admin/HangSX?mess=1");
        }

        // GET: Admin/HangSX/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/HangSX/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HangSX/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // POST: Admin/HangSX/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // POST: Admin/HangSX/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
