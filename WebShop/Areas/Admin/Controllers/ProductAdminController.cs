using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        // GET: Admin/ProductAdmin
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            using (var con = new MyDBContext())
            {
                var model = con.Category.ToList();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Search(string s)
        {
            using (var con = new MyDBContext())
            {
                var model = con.Category.Where(x=>x.Name.Contains(s)).ToList();
                return View("Index",model);
            }
        }

        // GET: Admin/ProductAdmin/Details/5
        public ActionResult Details(int id)
        {
            using (var con = new MyDBContext())
            {
                var model = con.Category.Find(id);
                return View(model);
            }               
        }

        // GET: Admin/ProductAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductAdmin/Create
        [HttpPost]
        public ActionResult Create(Models.Trademark obj)
        {
            var con = new MyDBContext();
            con.Category.Add(obj);                   
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/ProductAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            using (var con = new MyDBContext())
            {
                var model = con.Category.Find(id);
                return View(model);
            }
        }

        // POST: Admin/ProductAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(Trademark model)
        {
            try
            {
                using (var con = new MyDBContext())
                {
                    var obj = con.Category.Find(model.ID_Trademark);
                    obj.Name = model.Name;
                    con.SaveChanges();
                    ViewBag.MessageEdit = "Success";
                    return RedirectToAction("Index");
                }
                    // TODO: Add update logic here

            }
            catch
            {
                ViewBag.MessageEdit = "Failed";
                return Redirect("/Admin/ProductAdmin/Edit/"+model.ID_Trademark);
            }
        }

        // GET: Admin/ProductAdmin/Delete/5
        public ActionResult Delete(int id,string Message)
        {
            try
            {
                using (var con = new MyDBContext())
                {
                    var obj = con.Category.FirstOrDefault(x=>x.ID_Trademark==id);
                    if(obj != null)
                    {
                        con.Category.Remove(obj);
                        con.SaveChanges();
                    }
                    ViewBag.Message = "Removed!!!";
                    return RedirectToAction("Index");

                }
            }
            catch
            {
                ViewBag.Message = "Remove Failed!!!";
                return Redirect("/Admin/ProductAdmin/Index");
            }
        }

        /*
        // POST: Admin/ProductAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(Trademark model)
        {
            try
            {
                using (var con = new MyDBContext())
                {
                    var obj = con.Category.Find(model.ID_Trademark);
                    con.Category.Remove(obj);
                    con.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return Redirect("/Admin/ProductAdmin/Delete/" + model.ID_Trademark);
            }
        }
        */
    }
}
