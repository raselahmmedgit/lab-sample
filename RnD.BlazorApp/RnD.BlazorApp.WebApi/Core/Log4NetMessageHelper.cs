using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Core
{
    public static class Log4NetMessageHelper
    {
        public static string FormateMessage(string description, string methodName, string userId = "Anonymous User", string status = "", string message = "")
        {
            string strMessage = string.Empty; ;

            strMessage = $"Description: {description}, MethodName: {methodName}, Message: {message}, Status: {status}, UserId: {userId}, RequestDateTimeUtc: {DateTime.UtcNow}";

            return strMessage;
        }

        public static string FormateMessageForStart(string methodName, string userId = "Anonymous User", string status = "", string message = "")
        {
            string strMessage = string.Empty; ;

            strMessage = $"Description: Request Start, MethodName: {methodName}, Message: {message}, Status: {status}, UserId: {userId}, RequestDateTimeUtc: {DateTime.UtcNow}";

            return strMessage;
        }

        public static string FormateMessageForEnd(string methodName, string userId = "Anonymous User", string status = "", string message = "")
        {
            string strMessage = string.Empty; ;

            strMessage = $"Description: Request End, MethodName: {methodName}, Message: {message}, Status: {status}, UserId: {userId}, RequestDateTimeUtc: {DateTime.UtcNow}";

            return strMessage;
        }

        public static string FormateMessageForException(Exception ex, string methodName, string userId = "Anonymous User")
        {
            string strMessage = string.Empty; ;

            string exceptionMessage = "";// ex.Message;
            //string innerExceptionMessage = ""; // ex.InnerException != null ? ex.InnerException.Message : "";
            if (ex.InnerException != null)
            {
                if (ex.InnerException.InnerException != null)
                {
                    exceptionMessage = ex.InnerException.InnerException.Message;
                }
                else
                {
                    exceptionMessage = ex.InnerException.Message;
                }
            }
            else if (ex.Message != null)
            {
                exceptionMessage = ex.Message;
            }

            string stackTraceMessage = ex.StackTrace != null ? ex.StackTrace.ToString() : "";

            strMessage = $"Description: Error!, MethodName: {methodName}, Exception: {exceptionMessage}, StackTrace: {stackTraceMessage}, UserId: {userId}";

            return strMessage;
        }

        public static string FormateMessageForException(Exception ex, string methodName)
        {
            string strMessage = string.Empty; ;

            string exceptionMessage = "";// ex.Message;
            //string innerExceptionMessage = ""; // ex.InnerException != null ? ex.InnerException.Message : "";
            if (ex.InnerException != null)
            {
                if (ex.InnerException.InnerException != null)
                {
                    exceptionMessage = ex.InnerException.InnerException.Message;
                }
                else
                {
                    exceptionMessage = ex.InnerException.Message;
                }
            }
            else if (ex.Message != null)
            {
                exceptionMessage = ex.Message;
            }

            string stackTraceMessage = ex.StackTrace != null ? ex.StackTrace.ToString() : "";

            strMessage = $"Description: Error!, MethodName: {methodName}, Exception: {exceptionMessage}, StackTrace: {stackTraceMessage}";

            return strMessage;
        }

        public static string LogFormattedMessageForRequestStart(string actionName, string loginAppUserId = "Anonymous User", string AdditionalInfo = "")
        {
            string message = $"Request start on Action: {actionName}, LoginAppUserId = {loginAppUserId}";
            message += $", Additional info: {AdditionalInfo}";
            return message;
        }
        public static string LogFormattedMessageForRequestSuccess(string actionName, string loginAppUserId = "Anonymous User", string AdditionalInfo = "")
        {
            string message = $"Request successfully completed on Action: {actionName}, LoginAppUserId = {loginAppUserId}";
            message += $", Additional info: {AdditionalInfo}";
            return message;
        }
        public static string LogFormattedMessageForRequestFailed(Exception ex, string actionName, string loginAppUserId = "Anonymous User", string AdditionalInfo = "")
        {
            string message = $"Request failied on Action: {actionName}, LoginAppUserId = {loginAppUserId}";
            message += $", Additional info: {AdditionalInfo}";

            string exceptionMessage = "";// ex.Message;
            if (ex.InnerException != null)
            {
                if (ex.InnerException.InnerException != null)
                {
                    exceptionMessage = ex.InnerException.InnerException.Message;
                }
                else
                {
                    exceptionMessage = ex.InnerException.Message;
                }
            }
            else if (ex.Message != null)
            {
                exceptionMessage = ex.Message;
            }

            string stackTraceMessage = ex.StackTrace != null ? ex.StackTrace.ToString() : "";
            message += $", Exception: {exceptionMessage}, StackTrace: {stackTraceMessage}";
            return message;
        }
        public static string FormattedMessageForApiCall(string id)
        {
            return "Api call for " + id;
        }
    }
}
