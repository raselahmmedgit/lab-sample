using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using CityGlassCompany.WebSite.Core;
using CityGlassCompany.WebSite.Helpers;
using CityGlassCompany.WebSite.Managers;
using CityGlassCompany.WebSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using CityGlassCompany.WebSite.Helper;

namespace CityGlassCompany.WebSite.Controllers
{
    [Route("Employment")]
    public class EmploymentController : BaseController
    {
        #region Global Variable Declaration
        private readonly ILogger<EmploymentController> _logger;
        private readonly IMapper _iMapper;
        private readonly IEmploymentApplicationManager _iEmploymentApplicationManager;
        #endregion

        #region Constructor
        public EmploymentController(ILogger<EmploymentController> logger
            , IMapper iMapper
            , IEmploymentApplicationManager iEmploymentApplicationManager)
        {
            _logger = logger;
            _iMapper = iMapper;
            _iEmploymentApplicationManager = iEmploymentApplicationManager;
        }
        #endregion

        #region Actions
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var employmentApplicationViewModelList = await _iEmploymentApplicationManager.GetEmploymentApplicationsAsync();
                return View(employmentApplicationViewModelList);
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iEmploymentApplicationManager.GetDataTablesResponseAsync(request);
                return new DataTablesJsonResult(response, true);
            }
            catch (Exception ex)
            {
                return ErrorPartialView(ex);
            }
        }

        [Route("Details")]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var employmentApplicationViewModel = await _iEmploymentApplicationManager.GetEmploymentApplicationAsync(id);

                if (employmentApplicationViewModel != null)
                {
                    return View(employmentApplicationViewModel);
                }
                else
                {
                    return ErrorView(ExceptionHelper.ExceptionErrorMessageForNullObject());
                }
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                var employmentApplicationViewModel = new EmploymentApplicationViewModel();
                return View(employmentApplicationViewModel);
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmploymentApplicationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _result = await _iEmploymentApplicationManager.InsertEmploymentApplicationAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [Route("Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var employmentApplicationViewModel = await _iEmploymentApplicationManager.GetEmploymentApplicationAsync(id);

                if (employmentApplicationViewModel != null)
                {
                    return View(employmentApplicationViewModel);
                }
                else
                {
                    return ErrorView(ExceptionHelper.ExceptionErrorMessageForNullObject());
                }
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EmploymentApplicationViewModel model)
        {
            try
            {
                var employmentApplicationViewModel = await _iEmploymentApplicationManager.GetEmploymentApplicationAsync(id);

                if (id == model.Id)
                {
                    if (ModelState.IsValid)
                    {
                        _result = await _iEmploymentApplicationManager.UpdateEmploymentApplicationAsync(model);

                        return RedirectToAction(nameof(Index));
                    }
                    return View(model);
                }
                else
                {
                    return ErrorView(ExceptionHelper.ExceptionErrorMessageForNullObject());
                }
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [Route("Delete")]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var employmentApplicationViewModel = await _iEmploymentApplicationManager.GetEmploymentApplicationAsync(id);

                if (employmentApplicationViewModel != null)
                {
                    return View(employmentApplicationViewModel);
                }
                else
                {
                    return ErrorView(ExceptionHelper.ExceptionErrorMessageForNullObject());
                }
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [Route("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                if (id != null || id != string.Empty)
                {
                    _result = await _iEmploymentApplicationManager.DeleteEmploymentApplicationAsync(id);
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

        [Route("Application")]
        [HttpGet]
        public  IActionResult Application()
        {
            try
            {
                EmploymentApplicationViewModel model = new EmploymentApplicationViewModel();
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "Application"));
                return ErrorView(ex);
            }
        }

        [Route("Application")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Application(EmploymentApplicationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _result = await _iEmploymentApplicationManager.InsertEmploymentApplicationAsync(model);
                    //return RedirectToAction("Index", "Home");
                    return View("~/Views/Employment/ApplicationSuccess.cshtml");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "Application"));
                return ErrorView(ex);
            }
        }

        private bool EmploymentApplicationExists(string id)
        {
            var model = _iEmploymentApplicationManager.GetEmploymentApplicationAsync(id);
            if (model != null) {
                return true;
            }
            else {
                return false;
            }
        }

        #endregion
    }
}
