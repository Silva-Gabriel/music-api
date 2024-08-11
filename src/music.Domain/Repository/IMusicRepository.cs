using music.Domain.Models;

namespace music.Domain.Repository
{
    public interface IMusicRepository
    {
        Task<IEnumerable<Music>> GetMusicsLibrary();
        Task<int> PostMusicLibrary(Music music);
        Task<Music> GetMusicById(long id);
    }
}