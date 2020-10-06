using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab.DataStore.App.EntityModels.Type;
using lab.DataStore.App.Models;
using lab.DataStore.App.DataContext;
using Microsoft.Extensions.Logging;
using AutoMapper;
using lab.DataStore.App.BLL;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using lab.DataStore.App.PageViewModels;
using lab.DataStore.App.ViewModels;
using lab.DataStore.App.Helpers;

namespace lab.DataStore.App.Controllers
{
    public class AddressTypeController : BaseController
    {
        #region Global Variable Declaration
        private readonly ILogger<AddressTypeController> _logger;
        private readonly IMapper _iMapper;
        private readonly IAddressTypeManager _iAddressTypeManager;
        #endregion

        #region Constructor
        public AddressTypeController(ILogger<AddressTypeController> logger
            , IMapper iMapper
            , IAddressTypeManager iAddressTypeManager
        )
        {
            _logger = logger;
            _logger.LogInformation("AddressTypeController instance created...");
            _iMapper = iMapper;
            _iAddressTypeManager = iAddressTypeManager;
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

        public IActionResult Create()
        {
            try
            {
                var model = new AddressTypePageViewModel();
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

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var addressTypeViewModel = await _iAddressTypeManager.GetAddressTypeAsync(id);
                var model = _iMapper.Map<AddressTypeViewModel, AddressTypePageViewModel>(addressTypeViewModel);

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

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var addressTypeViewModel = await _iAddressTypeManager.GetAddressTypeAsync(id);
                var model = _iMapper.Map<AddressTypeViewModel, AddressTypePageViewModel>(addressTypeViewModel);

                if (model != null)
                {
                    return PartialView("_Details", model);
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
        public async Task<IActionResult> Save([Bind("TypeId,TypeName")] AddressTypePageViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var addressTypeViewModel = _iMapper.Map<AddressTypePageViewModel, AddressTypeViewModel>(viewModel);

                    //add
                    if (viewModel.TypeId == 0)
                    {
                        _result = await _iAddressTypeManager.InsertAddressTypeAsync(addressTypeViewModel);
                    }
                    else if (viewModel.TypeId > 0) //edit
                    {
                        _result = await _iAddressTypeManager.UpdateAddressTypeAsync(addressTypeViewModel);
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

                return JsonResult(_result);
            }
            catch (Exception ex)
            {
                return JsonResult(ex);
            }
        }

        #endregion
    }
}
