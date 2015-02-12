using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.Apps.Models;
using RnD.Apps.Helpers;
using RnD.Apps.ViewModels;

namespace RnD.Apps.Controllers
{
    public class CategoryController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        //
        // GET: /Category/

        public ViewResult Index()
        {
            return View(_db.Categories.ToList());
            //return View();
        }

        // for display datatable
        public ActionResult GetCategories(DataTableParamModel param)
        {
            var categories = _db.Categories.ToList();

            var viewProducts = categories.Select(cat => new CategoryTableModels() { CategoryId = Convert.ToString(cat.CategoryId), Name = cat.Name });

            IEnumerable<CategoryTableModels> filteredProducts;

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filteredProducts = viewProducts.Where(cat => (cat.Name ?? "").Contains(param.sSearch)).ToList();
            }
            else
            {
                filteredProducts = viewProducts;
            }

            var viewOdjects = filteredProducts.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from catMdl in viewOdjects
                         select new[] { catMdl.CategoryId, catMdl.Name };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = categories.Count(),
                iTotalDisplayRecords = filteredProducts.Count(),
                aaData = result
            },
                            JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /Category/Details/By ID

        public ActionResult Details(int id)
        {
            Category category = _db.Categories.Find(id);

            //return View(category);
            return PartialView("_Details", category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            //return View();
            //return PartialView("_Create");
            return PartialView("_CreateOrEdit");
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Categories.Add(category);
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(category);
                //return PartialView("_Create", category);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }

        }

        //
        // POST: /Category/Save

        [HttpPost]
        public ActionResult Save(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (category.CategoryId == 0)
                    {
                        _db.Categories.Add(category);
                    }
                    else if (category.CategoryId > 0) //edit
                    {
                        Category model = _db.Categories.Find(category.CategoryId);

                        if (model != null)
                        {

                            model.CategoryId = category.CategoryId;
                            model.Name = category.Name;
                            _db.Entry(model).State = EntityState.Modified;

                        }
                        else
                        {
                            return Content(Boolean.FalseString + "|" + "warning" + "Model null error");
                        }
                    }

                    _db.SaveChanges();

                    return Content(Boolean.TrueString + "|" + "Add" + "|" + "error" + "Saved Successfully.");

                }

                return Content(Boolean.FalseString + "|" + "error" + "Model State error");
            }
            catch (Exception ex)
            {
                return Content(Boolean.FalseString + "|" + "error" + ex.Message.ToString());
            }
        }

        //
        // GET: /Category/Edit/By ID

        public ActionResult Edit(int id)
        {
            Category category = _db.Categories.Find(id);

            //return View(category);
            //return PartialView("_Edit", category);
            return PartialView("_CreateOrEdit", category);
        }

        //
        // POST: /Category/Edit/By ID

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(category).State = EntityState.Modified;
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(category);
                //return PartialView("_Edit", category);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /Category/Delete/By ID

        public ActionResult Delete(int id)
        {
            Category category = _db.Categories.Find(id);

            //return View(category);
            return PartialView("_Delete", category);
        }

        //
        // POST: /Category/Delete/By ID

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Category category = _db.Categories.Find(id);
                if (category != null)
                {
                    //_db.Categories.Remove(category);
                    //_db.SaveChanges();

                    //return RedirectToAction("Index");
                    //return Content(Boolean.TrueString);
                    return Content("Could not able to delete.");
                }
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        public PartialViewResult GetProducts(string catId)
        {
            int categoryId = Convert.ToInt32(catId);

            var category = _db.Categories.Where(x => x.CategoryId == categoryId).FirstOrDefault();

            var products = _db.Products.Where(x => x.CategoryId == category.CategoryId).ToList();

            IEnumerable<ProductTableModels> productTableModels = products.Count() == 0 ? null : (products.Select(pro => new ProductTableModels
            {
                Name = pro.Name,
                Price = Convert.ToString(pro.Price)
            }).ToList());


            return PartialView("_ProductList", productTableModels);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}