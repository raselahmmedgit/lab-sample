using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AeonicTech.TestApp.Exceptions;
using System;

namespace AeonicTech.TestApp.Helpers
{
    public static class ModalHelper
    {
        public static string Content(Result result)
        {
            string strContent = string.Empty;

            if (result.Success)
            {
                strContent = (Boolean.TrueString.ToString() + "_" + result.ErrorType + "_" + result.Error).ToString();
            }
            else
            {
                strContent = (Boolean.FalseString.ToString() + "_" + result.ErrorType + "_" + result.Error).ToString();
            }

            return strContent;
        }

        public static string ContentError()
        {
            string result = string.Empty;
            result = (Boolean.FalseString + "_" + MessageHelper.MessageTypeDanger + "_" + MessageHelper.Error).ToString();
            return result;
        }

        public static string ContentError(System.Exception ex)
        {
            string result = string.Empty;
            ErrorPageViewModel errorPageViewModel = ExceptionHelper.ExceptionErrorMessageFormat(ex);
            string errorMessage = errorPageViewModel.ErrorMessage;
            result = (Boolean.FalseString + "_" + MessageHelper.MessageTypeDanger + "_" + errorMessage).ToString();
            return result;
        }

        public static string ContentModelError(ModelStateDictionary modelStateDictionary)
        {
            string result = string.Empty;
            string errorMessage = ExceptionHelper.ModelStateErrorFormat(modelStateDictionary);
            result = (Boolean.FalseString + "_" + MessageHelper.MessageTypeDanger + "_" + errorMessage).ToString();
            return result;
        }

        public static string ContentNullError()
        {
            string result = string.Empty;
            result = (Boolean.FalseString + "_" + MessageHelper.MessageTypeWarning + "_" + MessageHelper.NullError).ToString();
            return result;
        }

        #region JsonResult

        public static JsonResult Json(Result result)
        {
            var json = new
            {
                success = result.Success,
                error = result.Error,
                errortype = result.ErrorType
            };

            return new JsonResult(json);
        }

        public static JsonResult JsonError()
        {
            var json = new
            {
                success = false,
                error = MessageHelper.MessageTypeDanger,
                errortype = MessageHelper.Error
            };

            return new JsonResult(json);
        }

        public static JsonResult JsonError(System.Exception ex)
        {
            ErrorPageViewModel errorPageViewModel = ExceptionHelper.ExceptionErrorMessageFormat(ex);
            string errorMessage = errorPageViewModel.ErrorMessage;

            var json = new
            {
                success = false,
                error = MessageHelper.MessageTypeDanger,
                errortype = errorMessage
            };

            return new JsonResult(json);
        }

        public static JsonResult JsonModelError(ModelStateDictionary modelStateDictionary)
        {
            string errorMessage = ExceptionHelper.ModelStateErrorFormat(modelStateDictionary);

            var json = new
            {
                success = false,
                error = MessageHelper.MessageTypeDanger,
                errortype = errorMessage
            };

            return new JsonResult(json);
        }

        public static JsonResult JsonNullError()
        {
            var json = new
            {
                success = false,
                error = MessageHelper.MessageTypeWarning,
                errortype = MessageHelper.NullError
            };

            return new JsonResult(json);
        }

        #endregion
    }
}
