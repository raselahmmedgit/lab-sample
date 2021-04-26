using AeonicTech.TestApp.Controllers;
using AeonicTech.TestApp.Exceptions;
using AeonicTech.TestApp.Helpers;
using AeonicTech.TestApp.Managers;
using AeonicTech.TestApp.ViewModels;
using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AeonicTech.TestApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AddressController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly IAddressManager _iAddressManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public AddressController(IAddressManager iAddressManager
            , IMapper iMapper
        )
        {
            _iAddressManager = iAddressManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(AddressController));
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [HttpGet]
        [Route("/Address/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iAddressManager.GetDataTablesResponseAsync(request);
                return new DataTablesJsonResult(response, true);
            }
            catch (Exception ex)
            {
                return ErrorPartialView(ex);
            }
        }

        public IActionResult Add()
        {
            try
            {
                var model = new AddressEntityViewModel();
                if (model != null)
                {
                    return View("AddOrEdit", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "AddressMessage");
                    return RedirectToAction("Index", "Address");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Add[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "AddressMessage");
            return RedirectToAction("Index", "Address");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _iAddressManager.GetAddressEntityAsync(id);

                if (model != null)
                {
                    return View("AddOrEdit", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "AddressMessage");
                    return RedirectToAction("Index", "Address");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Edit[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "AddressMessage");
            return RedirectToAction("Index", "Address");
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var addressTypeViewModel = await _iAddressManager.GetAddressEntityAsync(id);
                var model = _iMapper.Map<AddressEntityViewModel, AddressEntityViewModel>(addressTypeViewModel);

                if (model != null)
                {
                    return View("Details", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "AddressMessage");
                    return RedirectToAction("Index", "Address");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Details[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "AddressMessage");
            return RedirectToAction("Index", "Address");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(AddressEntityViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (viewModel.AddressId == 0)
                    {
                        _result = await _iAddressManager.InsertAddressEntityAsync(viewModel);
                    }
                    else if (viewModel.AddressId > 0) //edit
                    {
                        _result = await _iAddressManager.UpdateAddressEntityAsync(viewModel);
                    }

                    if (_result.Success)
                    {
                        this.FlashSuccess(MessageHelper.Save, "AddressMessage");
                        return RedirectToAction("Index", "Address");
                    }
                    else
                    {
                        this.FlashError(_result.Error, "AddressMessage");
                        return View(viewModel);
                    }
                }
                else
                {
                    this.FlashError(ExceptionHelper.ModelStateErrorFirstFormat(ModelState), "AddressMessage");
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Save[POST]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "AddressMessage");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _result = await _iAddressManager.DeleteAddressEntityAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    this.FlashSuccess(MessageHelper.Delete, "AddressMessage");
                }
                else
                {
                    this.FlashError(_result.Error, "AddressMessage");
                }
                return JsonResult(_result);
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Delete[POST]"));
                _result = Result.Fail(MessageHelper.UnhandelledError);
                return JsonResult(_result);
            }
        }

        #endregion
    }
}
