namespace ShapeServer.Helpers
{
    public static class ApiResponseGenerator
    {
        public static ApiResponse<object> GenerateApiResponse(ServiceResult<object> serviceResult, int httpStatusCode)
        {
            return new ApiResponse<object>(
                type: ErrorTypeDocument.GetDocumentUri(httpStatusCode),
                title: serviceResult.ResultTitle,
                status: httpStatusCode,
                errors: serviceResult.Errors,
                data: serviceResult.Result
                );
        }

        public static ApiResponse<object> GenerateApiResponse(IDictionary<string, string[]> validationErrors, int httpStatusCode)
        {
            return new ApiResponse<object>(
                type: ErrorTypeDocument.GetDocumentUri(httpStatusCode),
                title: "One or more validation errors occurred.",
                status: httpStatusCode,
                errors: validationErrors
                );
        }
    }
}
