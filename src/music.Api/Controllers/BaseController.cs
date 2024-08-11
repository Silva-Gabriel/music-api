using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using music.Domain.Models.Response;

namespace music.Api.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IMediator Mediator; 

        public BaseController(IMediator mediator) => Mediator = mediator;

        [NonAction]
        public async Task<IActionResult> GetResponse(ApiResponse response)
        {
            if (response.StatusCode == HttpStatusCode.Created && !string.IsNullOrEmpty(response.ItemId))
            {
                Response.Headers.Add("Location", response.ItemId);
                return StatusCode(201);
            }

            return await Task.FromResult(StatusCode((int)response.StatusCode, response));
        }
    }
}