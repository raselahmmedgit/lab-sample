using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RnD.WebCoreApp.Data;
using RnD.WebCoreApp.DataTablesWrapper;
using RnD.WebCoreApp.Helpers;
using RnD.WebCoreApp.Models;

namespace RnD.WebCoreApp.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult DataTables()
        {
            return View();
        }

        // for display datatable
        public ActionResult GetDataTables(AppDataTablesRequest param)
        {
            try
            {
                var categoryList = _context.Category.ToList();

                IEnumerable<Category> filteredCategoryList;

                if (!string.IsNullOrEmpty(param.sSearch))
                {
                    filteredCategoryList = categoryList.Where(cat => (cat.Name ?? "").Contains(param.sSearch)).ToList();
                }
                else
                {
                    filteredCategoryList = categoryList;
                }

                var viewOdjects = filteredCategoryList.Skip(param.iDisplayStart).Take(param.iDisplayLength);

                var result = from cat in viewOdjects
                             select new[] { cat.Name, Convert.ToString(cat.CategoryId), };

                return Json(new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = categoryList.Count(),
                    iTotalDisplayRecords = filteredCategoryList.Count(),
                    aaData = result
                });

            }
            catch (Exception)
            {
                throw;
            }

            
        }

        // for display datatable
        public ActionResult GetDataTablesList(AppDataTablesRequest param)
        {
            try
            {
                var categoryList = _context.Category.ToList();

                IEnumerable<Category> filteredCategoryList;

                if (!string.IsNullOrEmpty(param.sSearch))
                {
                    filteredCategoryList = categoryList.Where(cat => (cat.Name ?? "").Contains(param.sSearch)).ToList();
                }
                else
                {
                    filteredCategoryList = categoryList;
                }

                var viewDataList = filteredCategoryList.Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

                //var result = from cat in viewDataList
                //             select new[] { cat.Name, Convert.ToString(cat.CategoryId), };

                var result = AppDataTablesResponse.CreateResponse(param, categoryList.Count(), filteredCategoryList.Count(), viewDataList);

                return Json(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult GetDataTablesListWrapper(IDataTablesRequest request)
        {
            // Nothing important here. Just creates some mock data.
            var categoryList = _context.Category.ToList();

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.
            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? categoryList
                : categoryList.Where(_item => _item.Name.Contains(request.Search.Value));

            // Paging filtered data.
            // Paging is rather manual due to in-memmory (IEnumerable) data.
            var dataPage = filteredData.Skip(request.Start).Take(request.Length);

            // Response creation. To create your response you need to reference your request, to avoid
            // request/response tampering and to ensure response will be correctly created.
            var response = DataTablesResponse.Create(request, categoryList.Count(), filteredData.Count(), dataPage);

            // Easier way is to return a new 'DataTablesJsonResult', which will automatically convert your
            // response to a json-compatible content, so DataTables can read it when received.
            return new DataTablesJsonResult(response, true);
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Category/Create
        public IActionResult CreateModal()
        {
            try
            {
                var model = new Category();
                if (model != null)
                {
                    return PartialView("_CreateOrEdit", model);
                }
                else
                {
                    return ErrorPartialView(ExceptionHelper.ExceptionErrorMessageForNullObject());
                }
            }
            catch (Exception ex)
            {
                return ErrorPartialView(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("CategoryId,Name")] Category category)
        {
            //https://stackoverflow.com/questions/35202804/submitting-a-razor-form-using-jquery-ajax-in-mvc6-using-the-built-in-functionali
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (category.CategoryId == 0)
                    {
                        _context.Add(category);
                        await _context.SaveChangesAsync();

                        _result = Result.Ok(MessageHelper.Save);
                    }
                    else if (category.CategoryId > 0) //edit
                    {
                        _context.Update(category);
                        await _context.SaveChangesAsync();

                        _result = Result.Ok(MessageHelper.Update);
                    }

                    return JsonResult(_result);
                }
                else
                {
                    return JsonResult(ModelState);
                }
            }
            catch (Exception ex)
            {
                return JsonResult(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveForReplaceMode([Bind("CategoryId,Name")] Category category)
        {
            //https://stackoverflow.com/questions/35202804/submitting-a-razor-form-using-jquery-ajax-in-mvc6-using-the-built-in-functionali
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (category.CategoryId == 0)
                    {
                        _context.Add(category);
                        await _context.SaveChangesAsync();

                        _result = Result.Ok(MessageHelper.Save);
                    }
                    else if (category.CategoryId > 0) //edit
                    {
                        _context.Update(category);
                        await _context.SaveChangesAsync();

                        _result = Result.Ok(MessageHelper.Update);
                    }

                    return Content(ModalHelper.Content(_result));

                }

                return Content(ModalHelper.ContentModelError(ModelState));
            }
            catch (Exception ex)
            {
                return Content(ModalHelper.ContentError(ex));
            }
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Name")] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(category);
                    await _context.SaveChangesAsync();

                    _result = Result.Ok(MessageHelper.Save);

                    this.FlashSuccess(_result.Error);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ModelStateErrorFormat(ModelState));
                }
            }
            catch (Exception ex)
            {
                this.FlashError(ExceptionHelper.ExceptionErrorMessageFormat(ex));

            }

            return RedirectResult("Index", "Category");
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Name")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (id > 0)
                {
                    var category = await _context.Category.FindAsync(id);
                    
                    if (category != null)
                    {
                        _context.Category.Remove(category);
                        await _context.SaveChangesAsync();

                        _result = Result.Ok(MessageHelper.Save);
                    }
                    else
                    {
                        _result = Result.Fail(MessageHelper.DeleteFail);
                    }
                    
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                return JsonResult(_result);

            }
            catch (Exception ex)
            {
                return JsonResult(ex);
            }
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
