using System.Text.Json.Serialization;

namespace music.Domain.Models.Response
{
    public class ApiPagination
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }

        [JsonPropertyName("showMore")]
        public bool ShowMore
        {
            get => Page < TotalPages;
        }
    }
}