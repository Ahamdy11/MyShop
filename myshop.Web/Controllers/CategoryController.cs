using Microsoft.AspNetCore.Mvc;
using myshop.Web.Data;
using myshop.Web.Models;

namespace myshop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // Create Category 
        [HttpGet] // User see the view of Creation 
        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost] // When user click on Create Button or Back To Index Button
        [ValidateAntiForgeryToken] // To save from Cross side forgery Attack (Server Side Validation)
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid) //Server Side Validation
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)  // Because Id is a primary key
        { 
            if(Id == null | Id == 0) 
            {
                NotFound();
            }
            var categoriesDB = _context.Categories.Find(Id);
            return View(categoriesDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category) 
        {
            if (ModelState.IsValid) //Server Side Validation
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)  // Because Id is a primary key
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var categoriesDB = _context.Categories.Find(Id);
            return View(categoriesDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? Id)  // Because Id is a primary key
        {
            var categoriesDB = _context.Categories.Find(Id);
            if (categoriesDB==null)
            {
                NotFound();
            }
            _context.Categories.Remove(categoriesDB);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
