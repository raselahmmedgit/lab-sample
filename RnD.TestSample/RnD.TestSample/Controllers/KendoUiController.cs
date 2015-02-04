using RnD.TestSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RnD.TestSample.Controllers
{
    public class KendoUiController : Controller
    {
        AppDbContext _db = new AppDbContext();

        //
        // GET: /KendoUi/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoriesRead()
        {
            var models = GetCategories();

            return Json(models);
        }

        //private IEnumerable<Category> GetCategories()
        private List<Category> GetCategories()
        {
            var categories = _db.Categories.ToList().Select(c => new Category { CategoryId = c.CategoryId, Name = c.Name });

            //return categories.AsQueryable();
            return categories.ToList();
        }
    }
}
