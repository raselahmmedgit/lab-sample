using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Core
{
    public class Result
    {
        public bool Success { get; }
        public object Data { set; get; }

        public string Error { get; }
        public string Id { get; set; }

        public string ErrorType { get; }

        public Result()
        {
        }

        private Result(bool success, string error, string errorType)
        {
            Success = success;
            Error = error;
            ErrorType = errorType;
        }
        private Result(bool success, string id)
        {
            Success = success;
            Id = id;
        }
        private Result(bool success, string id, object data)
        {
            Success = success;
            Id = id;
            this.Data = data;
        }
        public static Result Info()
        {
            return new Result(false, MessageHelper.Info, MessageHelper.MessageTypeInfo);
        }

        public static Result Info(string error)
        {
            return new Result(false, error, MessageHelper.MessageTypeInfo);
        }

        public static Result Warning()
        {
            return new Result(false, MessageHelper.Warning, MessageHelper.MessageTypeWarning);
        }

        public static Result Warning(string error)
        {
            return new Result(false, error, MessageHelper.MessageTypeWarning);
        }

        public static Result Fail()
        {
            return new Result(false, MessageHelper.Error, MessageHelper.MessageTypeDanger);
        }

        public static Result Fail(string error)
        {
            return new Result(false, error, MessageHelper.MessageTypeDanger);
        }

        public static Result Ok()
        {
            return new Result(true, MessageHelper.Success, MessageHelper.MessageTypeSuccess);
        }

        public static Result Ok(string error)
        {
            return new Result(true, error, MessageHelper.MessageTypeSuccess);
        }
        public static Result Ok(bool success, string id)
        {
            return new Result(true, id);
        }
        public static Result Ok(object data)
        {
            return new Result(true, MessageHelper.Success, data);
        }
    }
}
