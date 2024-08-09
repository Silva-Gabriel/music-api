using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace music.Application.Commands.CreateMusic
{
    public class CreateMusicRequest : IRequest<CreateMusicResponse>
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("singer")]
        public string SingerName { get; set; }

        [Required]
        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }
    }
}