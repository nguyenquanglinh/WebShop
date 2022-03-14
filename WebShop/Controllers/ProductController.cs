using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using PagedList;
using PagedList.Mvc;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? page, int idt = 0, string s = null)
        {
            using (var con = new MyDBContext())
            {
                /*
                var listprd = new List<Product>();
                /*
                var listprd = new List<Product>();
                if(s != null)
                {
                    page = 1;
                }
                else
                {
                    c = s;
                }
                if(!string.IsNullOrEmpty(s))
                {
                    listprd = con.Products.Where(x => x.Name.Contains(s)).ToList();
                }
                else
                {
                    listprd = con.Products.ToList();
                }
                ViewBag.c = s;
                listprd = listprd.OrderByDescending(x => x.ID_Product).ToList();
                return View(listprd.ToPagedList(page ?? 1, 6));
               

                if (idt !=0)
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).ToList();
                }
                else
                {
                    listprd = con.Products.ToList();
                }
                */
                var listprd = new List<Product>();
                if (string.IsNullOrEmpty(s) && idt==0)
                {
                    listprd = con.Products.OrderBy(x => x.ID_Product).ToList();
                }
                else if(!string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.Where(x => x.Name.Contains(s)).OrderBy(x => x.ID_Product).ToList();
                }
                else if(string.IsNullOrEmpty(s) && idt != 0)
                {
                    ViewBag.category = idt;
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).OrderBy(x => x.ID_Product).ToList();
                }
                else
                {
                    ViewBag.category = idt;
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).Where(x => x.Name.Contains(s)).OrderBy(x => x.ID_Product).ToList();
                }
                ViewBag.s = s;
                ViewBag.idt = idt;
                listprd = listprd.OrderBy(x => x.ID_Product).ToList();
                return View(listprd.ToPagedList(page ?? 1, 6));              
            }
        }

        // GET: Product
        public ActionResult SortDes(int? page, int idt = 0, string s = null)
        {
            using (var con = new MyDBContext())
            {
                var listprd = new List<Product>();
                if (string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.OrderByDescending(x => x.Price).ToList();
                }
                else if (!string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.Where(x => x.Name.Contains(s)).OrderByDescending(x => x.Price).ToList();
                }
                else if (string.IsNullOrEmpty(s) && idt != 0)
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).OrderByDescending(x => x.Price).ToList();
                }
                else
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).Where(x => x.Name.Contains(s)).OrderByDescending(x => x.Price).ToList();
                }
                ViewBag.s = s;
                ViewBag.idt = idt;
                ViewBag.sortDes = "sortDes";
                listprd = listprd.OrderByDescending(x => x.Price).ToList();
                return View("Index", listprd.ToPagedList(page ?? 1, 6));
            }
        }

        // GET: Product
        public ActionResult SortAsc(int? page, int idt = 0, string s = null)
        {
            using (var con = new MyDBContext())
            {
                var listprd = new List<Product>();
                if (string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.OrderBy(x => x.Price).ToList();
                }
                else if (!string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.Where(x => x.Name.Contains(s)).OrderBy(x => x.Price).ToList();
                }
                else if (string.IsNullOrEmpty(s) && idt != 0)
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).OrderBy(x => x.Price).ToList();
                }
                else
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).Where(x => x.Name.Contains(s)).OrderBy(x => x.Price).ToList();
                }
                ViewBag.s = s;
                ViewBag.idt = idt;
                ViewBag.sortDes = "sortAsc";
                listprd = listprd.OrderBy(x => x.Price).ToList();
                return View("Index", listprd.ToPagedList(page ?? 1, 6));
            }
        }


        // GET: Product
        public ActionResult AtoZ(int? page, int idt = 0, string s = null)
        {
            using (var con = new MyDBContext())
            {
                var listprd = new List<Product>();
                if (string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.OrderBy(x => x.Name).ToList();
                }
                else if (!string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.OrderBy(x => x.Name).ToList();
                }
                else if (string.IsNullOrEmpty(s) && idt != 0)
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).OrderBy(x => x.Name).ToList();
                }
                else
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).Where(x => x.Name.Contains(s)).OrderBy(x => x.Name).ToList();
                }
                ViewBag.s = s;
                ViewBag.idt = idt;
                ViewBag.sortDes = "atoz";
                listprd = listprd.OrderBy(x => x.Name).ToList();
                return View("Index", listprd.ToPagedList(page ?? 1, 6));
            }
        }

        // GET: Product
        public ActionResult ZtoA(int? page, int idt = 0, string s = null)
        {
            using (var con = new MyDBContext())
            {
                var listprd = new List<Product>();
                if (string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.OrderByDescending(x => x.Name).ToList();
                }
                else if (!string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.Where(x => x.Name.Contains(s)).OrderByDescending(x => x.Name).ToList();
                }
                else if (string.IsNullOrEmpty(s) && idt != 0)
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).OrderByDescending(x => x.Name).ToList();
                }
                else
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).Where(x => x.Name.Contains(s)).OrderByDescending(x => x.Name).ToList();
                }
                ViewBag.s = s;
                ViewBag.idt = idt;
                ViewBag.sortDes = "ztoa";
                listprd = listprd.OrderByDescending(x => x.Name).ToList();
                return View("Index", listprd.ToPagedList(page ?? 1, 6));
            }
        }

        public ActionResult FromBetweenTo(int? page, int idt = 0, string s = null,string from = null,string to = null)
        {
           
            decimal fromPrice = Convert.ToDecimal(from);
            decimal toPrice = Convert.ToDecimal(to);
            using (var con = new MyDBContext())
            {
                var listprd = new List<Product>();
                if (string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.OrderByDescending(x => x.Name).Where(x => x.Price >= fromPrice && x.Price <= toPrice).ToList();
                }
                else if (!string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.Where(x => x.Name.Contains(s)).OrderByDescending(x => x.Name).Where(x => x.Price >= fromPrice && x.Price <= toPrice).ToList();
                }
                else if (string.IsNullOrEmpty(s) && idt != 0)
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).OrderByDescending(x => x.Name).Where(x => x.Price >= fromPrice && x.Price <= toPrice).ToList();
                }
                else
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).Where(x => x.Name.Contains(s)).OrderByDescending(x => x.Name).Where(x => x.Price >= fromPrice && x.Price <= toPrice).ToList();
                }
                ViewBag.s = s;
                ViewBag.idt = idt;
                ViewBag.sortDes = "fromTo";
                ViewBag.from = fromPrice;
                ViewBag.to = toPrice;
                listprd = listprd.OrderByDescending(x => x.Name).Where(x => x.Price >= fromPrice && x.Price <= toPrice).ToList();
                return View("Index", listprd.ToPagedList(page ?? 1, 6));
            }
        }

        /*
        [HttpPost]
        public ActionResult Index(int? page,int idt =0, string s=null)
        {
            using (var con = new MyDBContext())
            {
                var list = new List<Product>();
                var listprd = new List<Product>();
                if (string.IsNullOrEmpty(s) && idt==0)
                {
                    listprd = con.Products.OrderByDescending(x => x.Name).ToList();
                }
                else if(!string.IsNullOrEmpty(s) && idt == 0)
                {
                    listprd = con.Products.Where(x => x.Name.Contains(s)).OrderByDescending(x => x.Name).ToList();
                }
                else if(string.IsNullOrEmpty(s) && idt != 0)
                {
                    listprd = con.Products.Where(x => x.ID_Trademark == idt).OrderByDescending(x => x.Name).ToList();
                }
                else
                {
                    list = con.Products.Where(x => x.ID_Trademark == idt).ToList();
                    listprd = list.Where(x => x.Name.Contains(s)).OrderByDescending(x => x.Name).ToList();
                }
                ViewBag.idt = idt;
                ViewBag.s = s;
                return View(listprd);
            }
        }
        */
        /*
    [HttpPost]
    public ActionResult SearchTM(int id,int? page)
    {
        using (var con = new MyDBContext())
        {
            var model = con.Products.Where(x=>x.ID_Trademark == id).OrderByDescending(x => x.ID_Trademark).ToPagedList(page ?? 1, 6);
            return View("Index", model);
        }
    }
    */
    /*
        [ChildActionOnly]
        public ActionResult Menu()
        {
            using (var con = new MyDBContext())
            {
                var model = con.Categories.ToList();
                return PartialView(model);
            }
        }
        */

        [ChildActionOnly]
        public ActionResult TradeMark()
        {
            using (var con = new MyDBContext())
            {
                var model = con.Category.ToList();
                return PartialView(model);
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int id, string mess)
        {
            using (var con = new MyDBContext())
            {
                ViewBag.mes = mess;
                var model = con.Products.Where(x=>x.ID_Product == id).FirstOrDefault();
                return View(model);
            }
        }

        [ChildActionOnly]
        public ActionResult listdetail()
        {
            using (var con = new MyDBContext())
            {
                var model = con.Products.ToList();
                return PartialView(model);
            }
        }

        // POST: Product/Create
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
        //getCate
        public List<Trademark> getList()
        {
            using (var con = new MyDBContext())
            {
                return con.Category.ToList();
            }
        }
    }
}
