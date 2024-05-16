using _9p2.Models;
using Microsoft.AspNetCore.Mvc;

namespace _9p2.Controllers
{
    public class catController : Controller
    {
        private readonly mydb db;
        public catController(mydb db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
           var a= db.categories.ToList();
            return View(a);
        }
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add(category c)
        {
           var check = db.categories.Where(a => a.cat_name == c.cat_name).FirstOrDefault();
            if (check != null)
            {
                ViewBag.msg = "Category is already available!";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.categories.Add(c);
                    db.SaveChanges();
                    ModelState.Clear();
                }
            }

            return RedirectToAction("index");
        }
        public IActionResult edit(int id)
        {
            var change =db.categories.Find(id);
            return View(change);
        }
        [HttpPost]
        public IActionResult edit(category e, int id)
        {
            var row =db.categories.Find(id);
            row.cat_name = e.cat_name;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult delete(int id)
        {
            var del = db.categories.Find(id);
            db.categories.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
