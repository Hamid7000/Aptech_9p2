using _9p2.Models;
using Microsoft.AspNetCore.Mvc;

namespace _9p2.Controllers
{
    public class clientController : Controller
    {
        private readonly mydb db;
        public clientController(mydb db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var a = db.products.Take(6).ToList();
            return View(a);
        }
        public IActionResult all_product()
        {
            var a = db.products.ToList();
            return View(a);
        }
        public IActionResult filter_pro(int id)
        {
            var a = db.products.Where(a=>a.categorycat_id == id).ToList();
            return View(a);
        }
      

    }
}
