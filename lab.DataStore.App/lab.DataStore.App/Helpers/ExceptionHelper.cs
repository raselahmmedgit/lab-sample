using Microsoft.AspNetCore.Mvc.ModelBinding;
using lab.DataStore.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Helpers
{
    public static class ExceptionHelper
    {
        public static string ExceptionMessageFormat(System.Exception ex)
        {
            string message = "Error: There was a problem while processing your request: " + ex.Message;

            if (ex.InnerException != null)
            {
                System.Exception inner = ex.InnerException;
                if (inner is System.Data.Common.DbException)
                    message = "Database is currently experiencing problems. " + inner.Message;
                else if (inner is System.Data.DataException)
                    message = "Datebase is currently problem.";
                else if (inner is NullReferenceException)
                    message = "There are one or more required fields that are missing.";
                else if (inner is ArgumentException)
                {
                    string paramName = ((ArgumentException)inner).ParamName;
                    message = string.Concat("The ", paramName, " value is illegal.");
                }
                else if (inner is ApplicationException)
                    message = "Exception in application" + inner.Message;
                else
                    message = inner.Message;

            }

            return message;
        }

        public static string ExceptionMessageForNullObject()
        {
            string message = "Requested object could not found.";

            return message;
        }

        public static ErrorPageViewModel ExceptionErrorMessageFormat(System.Exception ex)
        {
            var errorPageViewModel = new ErrorPageViewModel();

            string message = "Error: There was a problem while processing your request: " + ex.Message;

            if (ex.InnerException != null)
            {
                System.Exception inner = ex.InnerException;
                if (inner is System.Data.Common.DbException)
                    message = "Database is currently experiencing problems. " + inner.Message;
                else if (inner is System.Data.DataException)
                    message = "Datebase is currently problem.";
                else if (inner is NullReferenceException)
                    message = "There are one or more required fields that are missing.";
                else if (inner is ArgumentException)
                {
                    string paramName = ((ArgumentException)inner).ParamName;
                    message = string.Concat("The ", paramName, " value is illegal.");
                }
                else if (inner is ApplicationException)
                    message = "Exception in application" + inner.Message;
                else
                    message = inner.Message;

            }

            errorPageViewModel.ErrorType = MessageHelper.MessageTypeDanger;
            errorPageViewModel.ErrorMessage = message;

            return errorPageViewModel;
        }

        public static ErrorPageViewModel ExceptionErrorMessageForNullObject()
        {
            var errorPageViewModel = new ErrorPageViewModel();

            string message = "Requested object could not found.";

            errorPageViewModel.ErrorType = MessageHelper.MessageTypeWarning;
            errorPageViewModel.ErrorMessage = message;

            return errorPageViewModel;
        }

        public static ErrorPageViewModel ExceptionErrorMessageForCommon()
        {
            var errorPageViewModel = new ErrorPageViewModel();

            string message = "Oops! Exception in application.";

            errorPageViewModel.ErrorType = MessageHelper.MessageTypeInfo;
            errorPageViewModel.ErrorMessage = message;

            return errorPageViewModel;
        }

        public static string ModelStateErrorFormat(ModelStateDictionary modelStateDictionary)
        {
            string message = @"<ul class='alert-ul'>";

            foreach (var modelStateValues in modelStateDictionary.Values)
            {
                if (modelStateValues.Errors.Any())
                {
                    foreach (var modelError in modelStateValues.Errors)
                    {
                        message += "<li>";
                        message += modelError.ErrorMessage;
                        message += "</li>";
                    }
                }
            }

            message += "</ul>";

            return message;
        }

        public static ErrorPageViewModel ModelStateError(ModelStateDictionary modelStateDictionary)
        {
            var errorPageViewModel = new ErrorPageViewModel();

            string message = @"<ul class='alert-ul'>";

            foreach (var modelStateValues in modelStateDictionary.Values)
            {
                if (modelStateValues.Errors.Any())
                {
                    foreach (var modelError in modelStateValues.Errors)
                    {
                        message += "<li>";
                        message += modelError.ErrorMessage;
                        message += "</li>";
                    }
                }
            }

            message += "</ul>";

            errorPageViewModel.ErrorType = MessageHelper.MessageTypeDanger;
            errorPageViewModel.ErrorMessage = message;

            return errorPageViewModel;
        }

    }
}
