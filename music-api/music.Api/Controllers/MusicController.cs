using Microsoft.AspNetCore.Mvc;

namespace music.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Dictionary<long, string>>> GetMusicAsync()
        {
            var musics = new List
            {
                new Dictionary<long, string>
                {
                    {1, "Sweet Child'O mine"},
                    {2, "Teste"}
                }
            };
            return await musics;
        }
    }
}