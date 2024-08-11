namespace music.Domain.Models.Response
{
    public class ApiDataResponse
    {
        public object Response { get; set; }
        public ApiDataResponse(object response)
        {
            Response = response;
        }
    }
}