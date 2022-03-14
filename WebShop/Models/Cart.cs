using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebShop.Models
{
    [Serializable]
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { set; get; }
    }
    public class Cart
    {
        private List<CartItem> lineCollection = new List<CartItem>();

        public void AddItem(Product sp, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.Product.ID_Product == sp.ID_Product)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartItem
                {
                    Product = sp,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void UpdateItem(Product sp, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.Product.ID_Product == sp.ID_Product)
                .FirstOrDefault();

            if (line != null)
            {
                if (quantity > 0)
                {
                    line.Quantity = quantity;
                }
                else
                {
                    lineCollection.RemoveAll(l => l.Product.ID_Product == sp.ID_Product);
                }
            }
        }

        public void IncreaseItem(Product sp)
        {
            CartItem line = lineCollection
                .Where(p => p.Product.ID_Product == sp.ID_Product)
                .FirstOrDefault();
            line.Quantity++;


        }

        public void DecreaseItem(Product sp)
        {
            CartItem line = lineCollection
                .Where(p => p.Product.ID_Product == sp.ID_Product)
                .FirstOrDefault();
            line.Quantity--;
            if(line.Quantity==0){
                lineCollection.RemoveAll(l => l.Product.ID_Product == sp.ID_Product);
            }
        }



        public void RemoveLine(Product sp)
        {
            lineCollection.RemoveAll(l => l.Product.ID_Product == sp.ID_Product);
        }

        public Decimal? ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);

        }
        public int? ComputeTotalProduct()
        {
            return lineCollection.Sum(e => e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }
    } 
}