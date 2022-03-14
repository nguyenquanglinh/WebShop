using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/ProductAdmin
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index(string mess)
        {
            using (var con = new MyDBContext())
            {
                ViewBag.mes = mess;
                ViewBag.List = con.Category.ToList();
                var model = con.Products.OrderByDescending(p => p.CreateDate).ToList();
                return View(model);
            }
        }

        [ChildActionOnly]
        public ActionResult CategoryID()
        {
            using (var con = new MyDBContext())
            {
                var model = con.Category.ToList();
                return PartialView(model);
            }
        }

        [HttpPost]
        public ActionResult Search(string s)
        {
            using (var con = new MyDBContext())
            {
                ViewBag.List = con.Category.ToList();
                var model = con.Products.Where(x => x.Name.Contains(s) || (x.ID_Product.ToString()).Contains(s)).ToList();
                return View("Index", model);
            }
        }

        // GET: Admin/ProductAdmin/Details/5
        public ActionResult ThongKeSplowquan(string mess)
        {
            using (var con = new MyDBContext())
            {
                ViewBag.mes = mess;
                ViewBag.List = con.Category.ToList();
                var model = con.Products.Where(x=> x.Quantity <=5).OrderBy(x => x.Quantity).ToList();               
                return View("Index",model);
            }
        }

        public ActionResult ThongKe()
        {
            using (var con = new MyDBContext())
            {
                var model = con.Database.SqlQuery<TKban>("thongkeban").ToList();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult ThongKeNgay(FormCollection form)
        {
            DateTime NgayA = DateTime.Parse(form["NgayA"]);
            DateTime NgayB = DateTime.Parse(form["NgayB"]);
            using (var con = new MyDBContext())
            {
                SqlParameter[] idParam =
                {
                    new SqlParameter {ParameterName = "@NgayA", Value = NgayA },
                    new SqlParameter {ParameterName = "@NgayB", Value = NgayB }
                };
                var model = con.Database.SqlQuery<TKban>("TKSpNgay @NgayA,@NgayB", idParam).ToList();
                return View("ThongKe", model);
            }
        }

        // GET: Admin/ProductAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductAdmin/Create
        [HttpPost]
        public ActionResult Create(Models.Product obj)
        {
            var con = new MyDBContext();
            obj.CreateDate = DateTime.Now;
            con.Products.Add(obj);
            con.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            using (var con = new MyDBContext())
            {
                var model = con.Products.Find(id);
                return View(model);
            }
        }

        // POST: Admin/ProductAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            try
            {
                using (var con = new MyDBContext())
                {
                    var obj = con.Products.Find(model.ID_Product);
                    obj.Name = model.Name;
                    obj.Price = model.Price;
                    obj.Quantity = model.Quantity;
                    con.SaveChanges();
                    ViewBag.MessageEdit = "Success";
                    return RedirectToAction("Index");
                }
                // TODO: Add update logic here

            }
            catch
            {
                ViewBag.MessageEdit = "Failed";
                return Redirect("/Admin/SanPham/Edit/" + model.ID_Product);
            }
        }

        // GET: Admin/ProductAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            var con = new MyDBContext();
            var check = con.OrderDetails.FirstOrDefault(o => o.ID_Product == id);
            if (check != null)
            {
                return Redirect("/Admin/SanPham?mess=2");
            }
            else
            {
                var obj = con.Products.FirstOrDefault(x => x.ID_Product == id);
                con.Products.Remove(obj);
                con.SaveChanges();
                return Redirect("/Admin/SanPham?mess=1");
            }
        }
        //Add Product

        public ActionResult Add(FormCollection form)
        {
            var con = new MyDBContext();
            Product product = new Product();
            var file = Request.Files["file"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(file.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Content/images/" + postedFileName);
            file.SaveAs(path);
            product.Avatar = postedFileName;
            product.Price = Int32.Parse(form["price"]);
            product.Quantity = Int32.Parse(form["quatity"]);
            product.Name =form["name"];
            product.ID_Trademark = Int32.Parse(form["trademark"]);
            product.Description = form["des"];
            product.Content = form["content"];
            product.CreateDate = DateTime.Now;
            con.Products.Add(product);
            con.SaveChanges();
            return Redirect("/Admin/SanPham?mess=1");
        }
        //Update
        public ActionResult Update(FormCollection form)
        {
            var con = new MyDBContext();
            var id = Int32.Parse(form["id"]);
            Product product = con.Products.FirstOrDefault(p => p.ID_Product == id);
            var file = Request.Files["file"];
            string postedFileName = null;
            if (file.FileName != "")
            {
                //Lấy thông tin từ input type=file có tên Avatar
                postedFileName = System.IO.Path.GetFileName(file.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("/Content/images/" + postedFileName);
                file.SaveAs(path);
            }
            else
            {
                postedFileName = form["ava"];
            }
            product.Avatar = postedFileName;
            product.Price = Int32.Parse(form["price"]);
            product.Quantity = Int32.Parse(form["quatity"]);
            product.Name = form["name"];
            product.ID_Trademark = Int32.Parse(form["trademark"]);
            product.Description = form["des"];
            product.Content = form["content"];
            con.SaveChanges();
            return Redirect("/Admin/SanPham?mess=1");
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
                    var obj = con.Products.Find(model.ID_Trademark);
                    con.Products.Remove(obj);
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
