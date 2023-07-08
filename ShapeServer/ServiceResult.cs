using ShapeServer.Helpers;

namespace ShapeServer
{
    public class ServiceResult<T>
    {
        public bool Success { get; }
        public ServiceErrorType? ErrorType { get; }
        public IDictionary<string, string[]>? Errors { get; }
        public string ResultTitle { get; }
        public string Message { get; }
        public T? Result { get; }

        public ServiceResult(bool success, string resultTitle,
            string message, ServiceErrorType? errorType = null,
            T? result = default, IDictionary<string, string[]>? errors = null)
        {
            Result = result;
            Message = message;
            Success = success;
            Errors = errors;
            ErrorType = errorType;
            ResultTitle = resultTitle;
        }
    }
}
