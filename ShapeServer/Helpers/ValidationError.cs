namespace ShapeServer.Helpers
{
    public static class ValidationError
    {
        public static IDictionary<string, string> GetErrors(List<FluentValidation.Results.ValidationFailure> Errors)
        {
            var result = new Dictionary<string, string>();

            Errors.ForEach(error =>
            {
                result[error.PropertyName] = error.ErrorMessage;
            });

            return result;
        }
    }
}
