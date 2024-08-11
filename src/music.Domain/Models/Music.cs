using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace music.Domain.Models
{
    public class Music
    {
        [Required]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("singer")]
        public string SingerName { get; set; }

        [Required]
        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [JsonPropertyName("style_id")]
        public int StyleId { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }
}