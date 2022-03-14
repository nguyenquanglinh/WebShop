using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index(string mess)
        {
            using (var con = new MyDBContext())
            {
                ViewBag.mes = mess;
                var model = con.Orders.OrderByDescending(o => o.CreateDate).ToList();
                return View(model);
            }
        }

        public ActionResult ThongKe(DateTime NgayA, DateTime NgayB)
        {
            using (var con = new MyDBContext())
            {
                var model = con.Orders.Where(x => x.CreateDate >=NgayA && x.CreateDate<=NgayB).ToList();
                return View("Index", model);
            }
        }

        [HttpPost]
        public ActionResult Search(string s)
        {
            using (var con = new MyDBContext())
            {
                ViewBag.List = con.Category.ToList();
                var model = con.Orders.Where(x => x.ID_Order.ToString().Contains(s)).ToList();
                return View("Index", model);
            }
        }

        //Update
        public ActionResult Update(FormCollection form)
        {
            var con = new MyDBContext();
            var id = Int32.Parse(form["id"]);
            Order order = con.Orders.FirstOrDefault(p => p.ID_Order == id);
            /*order.ID_Order = id;
            order.Name = order.Name;
            order.Phone = order.Phone;
            order.Address = order.Address;
            order.CreateDate = order.CreateDate;
            order.Note = order.Note;
            order.Email = order.Email;*/
            order.Status = form["status"];
            con.SaveChanges();
            return Redirect("/Admin/DonHang?mess=1");
        }
        //Detail
        public ActionResult Detail(int id)
        {
            using (var con = new MyDBContext())
            {
                ViewBag.ID = id;
                ViewBag.List = con.OrderDetails.Where(o => o.ID_Order == id).ToList();
                return View();
            }
        }
        //GetProduct
        public Product getProduct(long id)
        {
            var con = new MyDBContext();
            return con.Products.FirstOrDefault(p => p.ID_Product == id);
        }
    }
}