using ShapeServer.Helpers;

namespace ShapeServer
{
    public class ServiceResult<T>
    {
        public bool Success { get; }
        public ServiceError? Error { get; }
        public string Message { get; }
        public T? Result { get; }

        public ServiceResult(bool success, string message, ServiceError? error = null, T? result = default)
        {
            Error = error;
            Result = result;
            Message = message;
            Success = success;
        }
    }
}
