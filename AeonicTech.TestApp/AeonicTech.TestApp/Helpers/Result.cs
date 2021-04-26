namespace AeonicTech.TestApp.Helpers
{
    public class Result
    {
        public bool Success { get; }

        public string Error { get; }

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
    }
}
