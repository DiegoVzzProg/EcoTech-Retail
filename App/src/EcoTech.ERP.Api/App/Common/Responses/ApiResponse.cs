namespace EcoTech.ERP.Api.App.Common.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T DataList { get; set; }
        public string Message { get; set; }

        public ApiResponse(T data, string message = "", bool success = true)
        {
            Success = success;
            DataList = data;
            Message = message;
        }
    }
}
