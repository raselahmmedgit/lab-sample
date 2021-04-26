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
    public class AddressTypeController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly IAddressTypeManager _iAddressTypeManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public AddressTypeController(IAddressTypeManager iAddressTypeManager
            , IMapper iMapper
        )
        {
            _iAddressTypeManager = iAddressTypeManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(AddressTypeController));
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
        [Route("/AddressType/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iAddressTypeManager.GetDataTablesResponseAsync(request);
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
                var model = new AddressTypeViewModel();
                if (model != null)
                {
                    return View("AddOrEdit", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "AddressTypeMessage");
                    return RedirectToAction("Index", "AddressType");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Add[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "AddressTypeMessage");
            return RedirectToAction("Index", "AddressType");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _iAddressTypeManager.GetAddressTypeAsync(id);

                if (model != null)
                {
                    return View("AddOrEdit", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "AddressTypeMessage");
                    return RedirectToAction("Index", "AddressType");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Edit[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "AddressTypeMessage");
            return RedirectToAction("Index", "AddressType");
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var addressTypeViewModel = await _iAddressTypeManager.GetAddressTypeAsync(id);
                var model = _iMapper.Map<AddressTypeViewModel, AddressTypeViewModel>(addressTypeViewModel);

                if (model != null)
                {
                    return View("Details", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "AddressTypeMessage");
                    return RedirectToAction("Index", "AddressType");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Details[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "AddressTypeMessage");
            return RedirectToAction("Index", "AddressType");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(AddressTypeViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (viewModel.TypeId == 0)
                    {
                        _result = await _iAddressTypeManager.InsertAddressTypeAsync(viewModel);
                    }
                    else if (viewModel.TypeId > 0) //edit
                    {
                        _result = await _iAddressTypeManager.UpdateAddressTypeAsync(viewModel);
                    }

                    if (_result.Success)
                    {
                        this.FlashSuccess(MessageHelper.Save, "AddressTypeMessage");
                        return RedirectToAction("Index", "AddressType");
                    }
                    else
                    {
                        this.FlashError(_result.Error, "AddressTypeMessage");
                        return View(viewModel);
                    }
                }
                else
                {
                    this.FlashError(ExceptionHelper.ModelStateErrorFirstFormat(ModelState), "AddressTypeMessage");
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Save[POST]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "AddressTypeMessage");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _result = await _iAddressTypeManager.DeleteAddressTypeAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    this.FlashSuccess(MessageHelper.Delete, "AddressTypeMessage");
                }
                else
                {
                    this.FlashError(_result.Error, "AddressTypeMessage");
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
