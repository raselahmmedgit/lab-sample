using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RnD.WebCoreApp.Helpers;
using RnD.WebCoreApp.Models;

namespace RnD.WebCoreApp
{
    public class BaseController : Controller
    {
        #region Global Variable Declaration
        internal Result _result = new Result();
        #endregion

        #region Constructor
        public BaseController()
        {
        }
        #endregion

        #region Actions

        internal IActionResult ErrorView(Exception ex)
        {
            var errorPageViewModel = new ErrorPageViewModel();
            errorPageViewModel = ExceptionHelper.ExceptionErrorMessageFormat(ex);
            return View("Error", errorPageViewModel);
        }

        internal IActionResult ErrorPartialView(Exception ex)
        {
            var errorPageViewModel = new ErrorPageViewModel();
            errorPageViewModel = ExceptionHelper.ExceptionErrorMessageFormat(ex);
            return PartialView("_ErrorModal", errorPageViewModel);
        }

        internal IActionResult ErrorView(ErrorPageViewModel errorPageViewModel)
        {
            return View("Error", errorPageViewModel);
        }

        internal IActionResult ErrorPartialView(ErrorPageViewModel errorPageViewModel)
        {
            return PartialView("_ErrorModal", errorPageViewModel);
        }

        internal IActionResult JsonResult(Exception ex)
        {
            return ModalHelper.JsonError(ex);
        }

        internal IActionResult JsonResult(Result result)
        {
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

        #endregion
    }
}