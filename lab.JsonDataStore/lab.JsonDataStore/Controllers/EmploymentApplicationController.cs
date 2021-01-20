using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using lab.JsonDataStore.Core;
using lab.JsonDataStore.Helpers;
using lab.JsonDataStore.Managers;
using lab.JsonDataStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace lab.JsonDataStore.Controllers
{
    public class EmploymentApplicationController : BaseController
    {
        #region Global Variable Declaration
        private readonly ILogger<EmploymentApplicationController> _logger;
        private readonly IMapper _iMapper;
        private readonly IEmploymentApplicationManager _iEmploymentApplicationManager;
        #endregion

        #region Constructor
        public EmploymentApplicationController(ILogger<EmploymentApplicationController> logger
            , IMapper iMapper
            , IEmploymentApplicationManager iEmploymentApplicationManager)
        {
            _logger = logger;
            _logger.LogInformation("EmploymentApplicationController instance created...");
            _iMapper = iMapper;
            _iEmploymentApplicationManager = iEmploymentApplicationManager;
        }
        #endregion

        #region Actions

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,DisplayName,EmailAddress,PhoneNumber,City,State,Country,ZipCode,IsArchived,IsDeleted,Id")] EmploymentApplicationViewModel model)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,DisplayName,EmailAddress,PhoneNumber,City,State,Country,ZipCode,IsArchived,IsDeleted,Id")] EmploymentApplicationViewModel model)
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

        [HttpPost, ActionName("Delete")]
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
