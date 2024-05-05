using MediatR;
using Microsoft.AspNetCore.Mvc;
using music.Application.Commands.CreateMusic;
using music.Application.Music;
using music.Domain.Models;

namespace music.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly IMediator Mediator;
        public MusicController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Music>> GetMusicAsync()
        {
            var response = await Mediator.Send(new MusicRequest());
            return await Task.FromResult(response.Musics);
        }

        [HttpPost]
        public async Task<IActionResult> PostMusicAsync(CreateMusicRequest request)
        {
            await Mediator.Send(new CreateMusicRequest
            {
                Name = request.Name,
                SingerName = request.SingerName,
                ReleasDate = request.ReleasDate
            });
            
            return Ok();
        }
    }
}