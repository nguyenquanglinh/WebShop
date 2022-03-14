using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = (Cart)Session["CartSession"];
            var list = new List<CartItem>();
            

            if (cart != null)
            {
                list = cart.Lines.ToList();
                ViewBag.TongTien = cart.ComputeTotalValue();
                ViewBag.TongSP = cart.ComputeTotalProduct();
                Session["CartitemQuan"] = ViewBag.TongSP;
            }
            else
            {
                Session["CartitemQuan"] = 0;
            }

            return View(list);
        }

        public ActionResult AddItem(int id, string returnURL)
        {
            var con = new MyDBContext();
            var cart = (Cart)Session["CartSession"];
            var product = con.Products.Find(id);

            

            if (cart != null)
            {
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
                Session["CartitemQuan"] = cart.ComputeTotalProduct();
                //Session.Add("CartSession", cart.ComputeTotalProduct());
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
                Session["CartitemQuan"] = cart.ComputeTotalProduct();
            }
            if (string.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("Index");
            }
            var url = returnURL + "?mess=success";
            return Redirect(url);
        }


        public ActionResult Remove(int id)
        {
            var con = new MyDBContext();
            var product = con.Products.Find(id);

            var cart = (Cart)Session["CartSession"];
            if (cart != null)
            {
                cart.RemoveLine(product);
                //Gán vào session
                Session["CartSession"] = cart;
                Session["CartitemQuan"] = cart.ComputeTotalProduct();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(int[] Ma, int[] SL)
        {
            var cart = (Cart)Session["CartSession"];
            var list = new List<CartItem>();
            var con = new MyDBContext();
            if (cart != null)
            {
                for (int i = 0; i < Ma.Count(); i++)
                {
                    var pro = con.Products.Find(Ma[i]);
                    cart.UpdateItem(pro, SL[i]);
                }

                Session["CartSession"] = cart;
                Session["CartitemQuan"] = cart.ComputeTotalProduct();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Increase(int id)
        {
            var cart = (Cart)Session["CartSession"];
            var list = new List<CartItem>();
            var con = new MyDBContext();
            var pro = con.Products.Find(id);
            cart.IncreaseItem(pro);
            Session["CartSession"] = cart;
            Session["CartitemQuan"] = cart.ComputeTotalProduct();

            return RedirectToAction("Index");
        }


        public ActionResult Decrease(int id)
        {
            var cart = (Cart)Session["CartSession"];
            var list = new List<CartItem>();
            var con = new MyDBContext();
            var pro = con.Products.Find(id);
            cart.DecreaseItem(pro);
            Session["CartSession"] = cart;
            Session["CartitemQuan"] = cart.ComputeTotalProduct();

            return RedirectToAction("Index");
        }

        // GET: Cart/Details/5
        public ActionResult Payment()
        {
            var cart = (Cart)Session["CartSession"];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = cart.Lines.ToList();
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(Models.Order hd)
        {
            var con = new MyDBContext();

            hd.CreateDate = DateTime.Now;
            hd.Status = "Đang xử lý";
            con.Orders.Add(hd);
            con.SaveChanges();
            var cart = (Cart)Session["CartSession"];
            var list = new List<CartItem>();
            if (cart != null)
            {
                foreach (CartItem it in cart.Lines)
                {
                    var obj = new OrderDetail();
                    obj.ID_Order = hd.ID_Order;
                    obj.ID_Product = it.Product.ID_Product;
                    obj.TotalPrice = it.Product.Price;
                    obj.Quantity = it.Quantity;
                    obj.CreateDate = hd.CreateDate;

                    con.OrderDetails.Add(obj);
                    con.SaveChanges();
                }
            }
            cart.Clear();
            Session["CartitemQuan"] = null;
            return View("Thankyou");
        }



        // GET: Cart/Create
        public ActionResult Thankyou()
        {
            return View();
        }

        // POST: Cart/Create
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

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
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

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
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

        private Payment payment;

        private Payment CreatePayment(APIContext apiContext, string redirecURL)
        {
            var listitem = new ItemList() { items = new List<Item>() };
            List<CartItem> listCart = (List<CartItem>)Session["CartSession"];
            foreach(var cartitem in listCart)
            {
                listitem.items.Add(new Item()
                {
                    name = cartitem.Product.Name,
                    currency = "USD",
                    price = cartitem.Product.Price.ToString(),
                    quantity = cartitem.Product.Quantity.ToString(),
                    sku = "sku"                  
                });
            }
            var payer = new Payer() { payment_method = "paypal" };
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirecURL,
                return_url = redirecURL
            };

            var details = new Details()
            {
                tax = "1",
                shipping = "2",
                subtotal = listCart.Sum(e => e.Quantity * e.Product.Price).ToString()
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = (Convert.ToDouble(details.tax) + Convert.ToDouble(details.shipping) + Convert.ToDouble(details.subtotal)).ToString()
            };

            var transationList = new List<Transaction>();
            transationList.Add(new Transaction()
            {
                description = "Testing transaction description",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list= listitem
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transationList,
                redirect_urls = redirUrls
            };
            return payment.Create(apiContext);
        }

        private Payment ExecutePayment(APIContext apiContext, string payerID, string paymentID)
        {
            var paymentExcution = new PaymentExecution()
            {
                payer_id = payerID
            };
            payment = new Payment()
            {
                id = paymentID
            };
            return payment.Execute(apiContext, paymentExcution);
        }

        public ActionResult PaymentWithPaypal()
        {
            APIContext apiContext = PaypalConfiguration.getAPIContext();
            try
            {
                string payerID = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerID))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "Cart/PaymentWithPaypal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = CreatePayment(apiContext, baseURI + "guid=" + guid);


                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;
                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = link.href;
                        }
                    }
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var excecutedPayment = ExecutePayment(apiContext, payerID, Session[guid] as string);
                    if(excecutedPayment.state.ToLower() != "approved")
                    {
                        return View("Failure");
                    }
                }

            }catch(Exception e)
            {
                PaypalLogger.Log("Error: " + e.Message);
                return View("Failure");
            }

            return View("Success");
        }
    }
}

