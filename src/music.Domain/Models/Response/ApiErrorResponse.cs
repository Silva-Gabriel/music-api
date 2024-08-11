using System.Text.Json.Serialization;

namespace music.Domain.Models.Response
{
    public class ApiErrorResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("detail")]
        public object Detail { get; set; }
    }
}