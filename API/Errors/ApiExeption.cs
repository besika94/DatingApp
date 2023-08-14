namespace API.Errors
{
    public class ApiExeption
    {
        public ApiExeption(int statusCode, string errorMessage, string details)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Details { get; set; }
    }
}
