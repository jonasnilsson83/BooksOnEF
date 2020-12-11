using System.Collections.Generic;

namespace BooksOnEF.Core
{
    public class Result<TObject> : ResultBase
    {
        public Result()
        {
            FailureMessages = new List<string>();
        }

        public TObject ResultObject { get; set; }

        public List<string> FailureMessages { get; set; }

        public static Result<TFailObject> Failure<TFailObject>(TFailObject obj, List<string> messages)
        {
            return new Result<TFailObject>() { Succeded = false, FailureMessages = messages };
        }

        public static Result<TFailObject> Failure<TFailObject>(TFailObject obj, string message)
        {
            return new Result<TFailObject>() { Succeded = false, FailureMessages = { message } };
        }

        public static Result<TSuccessObject> Success<TSuccessObject>(TSuccessObject obj)
        {
            return new Result<TSuccessObject>() { ResultObject = obj, Succeded = true };
        }

    }

    public class Result : Result<object>
    {
    }
}
