using MediatR;
using Microsoft.AspNetCore.Mvc;
using music.Application.Commands.CreateMusic;
using music.Application.Music;
using music.Application.Queries.GetById;
using music.Domain.Models;
using music.Domain.Models.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace music.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MusicController : BaseController
    {
        public MusicController(IMediator mediator) : base(mediator) { }

        [HttpGet("all")]
        public async Task<IActionResult> GetMusicAsync()
        {
            return await GetResponse(await Mediator.Send(new GetAllMusicsRequest()));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Post Music", Description = "Criar Música")]
        [SwaggerResponse(201, Type = typeof(ApiResponse))]
        [SwaggerResponse(400, Type = typeof(ApiErrorResponse))]
        [SwaggerResponse(500, Type = typeof(ApiErrorResponse))]
        public async Task<IActionResult> PostMusicAsync(CreateMusicRequest request)
        {
            return await GetResponse(await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get Music By Id", Description = "Consultar Música por ID ")]
        [SwaggerResponse(200, Type = typeof(Music))]
        [SwaggerResponse(400, Type = typeof(ApiErrorResponse))]
        [SwaggerResponse(404, Type = typeof(ApiErrorResponse))]
        [SwaggerResponse(500, Type = typeof(ApiErrorResponse))]
        public async Task<IActionResult> GetById(long id)
        {
            return await GetResponse(await Mediator.Send(new GetByIdRequest{Id = id}));
        }
    }
}