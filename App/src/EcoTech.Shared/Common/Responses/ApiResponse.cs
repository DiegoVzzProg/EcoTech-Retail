namespace EcoTech.Shared.Common.Responses
{
    public class ApiResponse<T>
    {
        public bool success { get; set; }
        public T data { get; set; }
        public string message { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(T _data, string _message = "", bool _success = true)
        {
            success = _success;
            data = _data;
            message = _message;
        }
    }
}
