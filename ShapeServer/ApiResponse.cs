namespace ShapeServer
{
    public class ApiResponse<T>
    {
        public string Type { get; }
        public string Title { get; }
        public int Status { get; }
        public string? TraceId { get; }
        public IDictionary<string, string[]>? Errors { get; }
        public T? Data { get; }

        public ApiResponse(
            string type,
            string title,
            int status,
            string? traceId = null,
            IDictionary<string, string[]>? errors = null,
            T? data = default)
        {
            Type = type;
            Title = title;
            Status = status;
            TraceId = traceId;
            Errors = errors;
            Data = data;
        }

    }
}
