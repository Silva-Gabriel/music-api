using Microsoft.AspNetCore.Mvc;

namespace music.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        [HttpGet]
        public async Task<int> GetMusicAsync()
        {
            return await Task.FromResult(1);
        }
    }
}