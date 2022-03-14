using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
 
namespace WebShop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Account model, string ReturnUrl)
        {
            using (var con = new MyDBContext())
            {
                var user = con.Logins.Where(x => x.Username == model.UserName && x.Password == model.Password).FirstOrDefault();
                if(user != null)
                {
                    model.Roles=(from a in con.Roles join b in con.Logins on a.ID_Role equals b.ID_Role
                                 where (a.Name != null && b.Username.Equals(model.UserName))
                                 select a.Name).ToList();
                    Session["Login"] = model;
                    Session["Username"] = model.UserName;
                    if(string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect("/Admin/SanPham/Index");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }
                }
                return View();
            }
        }
        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
