using _9p2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _9p2.Controllers
{
    public class proController : Controller
    {
        private readonly mydb db;
        private readonly  IWebHostEnvironment env;
        public proController(mydb db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public IActionResult Index()
        {
          var a=  db.products.Include(a => a.category).ToList();
            return View(a);
        }
        public IActionResult add()
        {
            ViewBag.data = new SelectList(db.categories, "cat_id", "cat_name");
            return View();
        }
        [HttpPost]
        public IActionResult add(product p,IFormFile pro_image)
        {
            ViewBag.data = new SelectList(db.categories, "cat_id", "cat_name");
            string pa = Path.Combine(env.WebRootPath, "images", Path.GetFileName(pro_image.FileName));
            pro_image.CopyTo(new FileStream(pa, FileMode.Create));
            p.pro_image = pro_image.FileName;
            db.products.Add(p);
            db.SaveChanges();
            ModelState.Clear();
            return View();
        }
        public IActionResult edit(int id)
        {
            var prod =db.products.Find(id);
            return View(prod);
        }
        [HttpPost]
        public IActionResult edit(product e, int id)
        {
            var prod = db.products.Find(id);
            prod.pro_name = e.pro_name;
            prod.price = e.price;
            prod.qty = e.qty;
            prod.categorycat_id = e.categorycat_id;
            prod.pro_image = e.pro_image;
            return RedirectToAction("Index");
        }
        public IActionResult delete(int id)
        {
            var del=db.products.Find(id);
            db.products.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
