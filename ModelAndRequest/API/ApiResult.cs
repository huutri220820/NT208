namespace ModelAndRequest.API
{
    public class ApiResult<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T payload { get; set; }

        public ApiResult()
        {

        }
        public ApiResult(bool success, string messge, T payload )
        {
            this.success = success;
            this.message = messge;
            this.payload = payload;
        }
    }
}
