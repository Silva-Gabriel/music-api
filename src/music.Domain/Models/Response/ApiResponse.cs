
using System.Net;
using System.Text.Json.Serialization;

namespace music.Domain.Models.Response
{
    public class ApiResponse
    {
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }

        [JsonIgnore]
        public string ItemId { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }

        [JsonPropertyName("pagination")]
        public ApiPagination Pagination { get; set; }

        [JsonPropertyName("error")]
        public ApiErrorResponse Error { get; set; }

        public ApiResponse() { }
        public ApiResponse(object data) => Data = data;
        public ApiResponse(string itemId) => ItemId = itemId;
        public ApiResponse(object data, ApiErrorResponse error, ApiPagination pagination = null)
        {
            Data = data;
            Pagination = pagination;
            Error = error;
        }

        public static T ErrorResponse<T>(HttpStatusCode statusCode, string error, string errorMessage, string errorDetail = null, object data = null) where T : ApiResponse, new()
        {
            return new T
            {
                Data = data,
                StatusCode = statusCode,
                Error = new ApiErrorResponse
                {
                    Code = error,
                    Message = errorMessage,
                    Detail = errorDetail
                }
            };
        }

        public static T OkResponse<T>(object data = null, string itemId = null, ApiPagination pagination = null) where T : ApiResponse, new()
        {
            return new T
            {
                StatusCode = HttpStatusCode.OK,
                Data = data,
                ItemId = itemId,
                Pagination = pagination
            };
        }

        public static T CreatedResponse<T>(string itemId = null, ApiPagination pagination = null) where T : ApiResponse, new()
        {
            return new T
            {
                StatusCode = HttpStatusCode.Created,
                ItemId = itemId,
                Pagination = pagination
            };
        }
    }
}