﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactProfile.App.Exception;
using ContactProfile.App.Helpers;
using ContactProfile.App.WebCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace ContactProfile.App.Controllers
{
    public class BaseController : Controller
    {
        #region Global Variable Declaration
        private readonly ILogger<BaseController> _logger;
        internal Result _result = new Result();
        #endregion

        #region Constructor
        public BaseController()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            _logger = loggerFactory.CreateLogger<BaseController>();
            _logger.LogInformation("BaseController instance created...");
        }
        #endregion

        #region Actions

        internal IActionResult ErrorView(System.Exception ex)
        {
            _logger.LogError(ex, "ErrorView");
            var errorPageViewModel = new ErrorPageViewModel();
            errorPageViewModel = ExceptionHelper.ExceptionErrorMessageFormat(ex);
            _logger.LogError(errorPageViewModel.ErrorMessage, "Error");
            return View("Error", errorPageViewModel);
        }

        internal IActionResult ErrorPartialView(System.Exception ex)
        {
            _logger.LogError(ex, "ErrorPartialView");
            var errorPageViewModel = new ErrorPageViewModel();
            errorPageViewModel = ExceptionHelper.ExceptionErrorMessageFormat(ex);
            _logger.LogError(errorPageViewModel.ErrorMessage, "Error");
            return PartialView("_ErrorModal", errorPageViewModel);
        }

        internal IActionResult ErrorView(ErrorPageViewModel errorPageViewModel)
        {
            _logger.LogError(errorPageViewModel.ErrorMessage, "Error");
            return View("Error", errorPageViewModel);
        }

        internal IActionResult ErrorPartialView(ErrorPageViewModel errorPageViewModel)
        {
            _logger.LogError(errorPageViewModel.ErrorMessage, "Error");
            return PartialView("_ErrorModal", errorPageViewModel);
        }

        internal IActionResult JsonResult(System.Exception ex)
        {
            _logger.LogError(ex, "JsonResult");
            return ModalHelper.JsonError(ex);
        }

        internal IActionResult JsonResult(Result result)
        {
            _logger.LogError(result.Error, "JsonResult");
            return ModalHelper.Json(result);
        }

        internal IActionResult JsonResult(ModelStateDictionary modelStateDictionary)
        {
            return ModalHelper.JsonModelError(modelStateDictionary);
        }

        internal IActionResult RedirectResult(string actionName)
        {
            return RedirectToAction(actionName);
        }

        internal IActionResult RedirectResult(string actionName, string controllerName)
        {
            return RedirectToAction(actionName, controllerName);
        }

        internal IActionResult RedirectResult(string actionName, string controllerName, string areaName)
        {
            return RedirectToAction(actionName, controllerName, new { @area = areaName });
        }

        internal bool IsAjaxRequest()
        {
            var request = Request;
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            return (request.Headers != null) && (request.Headers["X-Requested-With"] == "XMLHttpRequest");
        }

        #endregion
    }
}