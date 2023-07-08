namespace ShapeServer.Helpers
{
    public static class ErrorTypeDocument
    {
        private static IDictionary<int, string> responseTypes = new Dictionary<int, string>()
        {
            { 200, "https://tools.ietf.org/html/rfc7231#section-6.3.1" },   // OK
            { 201, "https://tools.ietf.org/html/rfc7231#section-6.3.2" },   // Created
            { 202, "https://tools.ietf.org/html/rfc7231#section-6.3.3" },   // Accepted
            { 203, "https://tools.ietf.org/html/rfc7231#section-6.3.4" },   // Non-Authoritative Information
            { 204, "https://tools.ietf.org/html/rfc7231#section-6.3.5" },   // No Content
            { 205, "https://tools.ietf.org/html/rfc7231#section-6.3.6" },   // Reset Content
            { 206, "https://tools.ietf.org/html/rfc7233#section-4.1" },     // Partial Content

            { 400, "https://tools.ietf.org/html/rfc7231#section-6.5.1" },   // Bad Request
            { 401, "https://tools.ietf.org/html/rfc7235#section-3.1" },     // Unauthorized
            { 402, "https://tools.ietf.org/html/rfc7231#section-6.5.2" },   // Payment Required
            { 403, "https://tools.ietf.org/html/rfc7231#section-6.5.3" },   // Forbidden
            { 404, "https://tools.ietf.org/html/rfc7231#section-6.5.4" },   // Not Found
            { 405, "https://tools.ietf.org/html/rfc7231#section-6.5.5" },   // Method Not Allowed
            { 406, "https://tools.ietf.org/html/rfc7231#section-6.5.6" },   // Not Acceptable
            { 407, "https://tools.ietf.org/html/rfc7235#section-3.2" },     // Proxy Authentication Required
            { 408, "https://tools.ietf.org/html/rfc7231#section-6.5.7" },   // Request Timeout
            { 409, "https://tools.ietf.org/html/rfc7231#section-6.5.8" },   // Conflict
            { 410, "https://tools.ietf.org/html/rfc7231#section-6.5.9" },   // Gone
            { 411, "https://tools.ietf.org/html/rfc7231#section-6.5.10" },  // Length Required
            { 412, "https://tools.ietf.org/html/rfc7232#section-4.2" },     // Precondition Failed
            { 413, "https://tools.ietf.org/html/rfc7231#section-6.5.11" },  // Payload Too Large
            { 414, "https://tools.ietf.org/html/rfc7231#section-6.5.12" },  // URI Too Long
            { 415, "https://tools.ietf.org/html/rfc7231#section-6.5.13" },  // Unsupported Media Type
            { 416, "https://tools.ietf.org/html/rfc7233#section-4.4" },     // Range Not Satisfiable
            { 417, "https://tools.ietf.org/html/rfc7231#section-6.5.14" },  // Expectation Failed

            { 500, "https://tools.ietf.org/html/rfc7231#section-6.6.1" },   // Internal Server Error
        };


        public static string GetDocumentUri(int httpStatusCode)
        {
            return responseTypes[httpStatusCode];
        }
    }
}
