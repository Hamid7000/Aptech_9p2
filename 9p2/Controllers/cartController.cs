using _9p2.Models;
using Microsoft.AspNetCore.Mvc;

namespace _9p2.Controllers
{
    public class cartController : Controller
    {
        private readonly mydb db;
        public cartController(mydb db)
        {
            this.db = db;
        }
        public IActionResult index()
        {
            return View();
        }
        public IActionResult addtocart(int id)
        {
            if (HttpContext.Session.GetString("cart")==null)
            {
                List<item> cart = HttpContext.Session.Get<List<item>>("cart") ?? new List<item>();
                cart.Add(new item { productdate=db.products.Find(id),cart_qty=1});
                HttpContext.Session.set("cart", cart);
            }
            else
            {
                List<item> cart = HttpContext.Session.Get<List<item>>("cart") ?? new List<item> { };
                int index = productIsInCart(id);
                if (index != -1)
                {
                    cart[index].cart_qty++;
                }
                else
                {
                    cart.Add(new item { productdate= db.products.Find(id), cart_qty =1});
                }
                HttpContext.Session.set("cart", cart);
            }
            return View("index");
        }
        public int productIsInCart(int id)
        {
            List<item> cart = HttpContext.Session.Get<List<item>>("cart") ?? new List<item>();
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].productdate.pro_id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
