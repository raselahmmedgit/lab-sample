using AeonicTech.TestApp.Exceptions;
using AeonicTech.TestApp.Helpers;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;

namespace AeonicTech.TestApp.Controllers
{
    public class BaseController : Controller
    {
        #region Global Variable Declaration
        private readonly ILog _log;
        internal Result _result = new Result();
        #endregion

        #region Constructor
        public BaseController()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            _log = LogManager.GetLogger(typeof(BaseController));
        }
        #endregion

        #region Actions

        internal IActionResult ErrorView(Exception ex)
        {
            _log.Error(LogMessageHelper.FormateMessageForException(ex, "ErrorView"));
            var errorPageViewModel = new ErrorPageViewModel();
            errorPageViewModel = ExceptionHelper.ExceptionErrorMessageFormat(ex);
            _log.Error(LogMessageHelper.FormateMessageForException(errorPageViewModel.ErrorMessage, "Error"));
            return View("Error", errorPageViewModel);
        }

        internal IActionResult ErrorPartialView(Exception ex)
        {
            _log.Error(LogMessageHelper.FormateMessageForException(ex, "ErrorPartialView"));
            var errorPageViewModel = new ErrorPageViewModel();
            errorPageViewModel = ExceptionHelper.ExceptionErrorMessageFormat(ex);
            _log.Error(LogMessageHelper.FormateMessageForException(errorPageViewModel.ErrorMessage, "Error"));
            return PartialView("_ErrorModal", errorPageViewModel);
        }

        internal IActionResult ErrorView(ErrorPageViewModel errorPageViewModel)
        {
            _log.Error(LogMessageHelper.FormateMessageForException(errorPageViewModel.ErrorMessage, "Error"));
            return View("Error", errorPageViewModel);
        }

        internal IActionResult ErrorPartialView(ErrorPageViewModel errorPageViewModel)
        {
            _log.Error(LogMessageHelper.FormateMessageForException(errorPageViewModel.ErrorMessage, "Error"));
            return PartialView("_ErrorModal", errorPageViewModel);
        }

        internal IActionResult ErrorNullView()
        {
            ErrorPageViewModel errorPageViewModel = new ErrorPageViewModel();
            errorPageViewModel.ErrorMessage = MessageHelper.NullError;
            errorPageViewModel.ErrorType = MessageHelper.MessageTypeDanger;
            _log.Error(LogMessageHelper.FormateMessageForException(errorPageViewModel.ErrorMessage, "Error"));
            return View("Error", errorPageViewModel);
        }

        internal IActionResult ErrorNullPartialView()
        {
            ErrorPageViewModel errorPageViewModel = new ErrorPageViewModel();
            errorPageViewModel.ErrorMessage = MessageHelper.NullError;
            errorPageViewModel.ErrorType = MessageHelper.MessageTypeDanger;
            _log.Error(LogMessageHelper.FormateMessageForException(errorPageViewModel.ErrorMessage, "Error"));
            return PartialView("_ErrorModal", errorPageViewModel);
        }

        internal IActionResult JsonResult(Exception ex)
        {
            _log.Error(LogMessageHelper.FormateMessageForException(ex, "JsonResult"));
            return ModalHelper.JsonError(ex);
        }

        internal IActionResult JsonResult(Result result)
        {
            _log.Error(LogMessageHelper.FormateMessageForException(result.Error, "JsonResult"));
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