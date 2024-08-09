using System.Data;
using Dapper;
using music.Domain.Models;
using music.Domain.Repository;

namespace music.Infrastructure.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly IDbConnection Connection;

        public MusicRepository(IDbConnection connection)
        {
            Connection = connection;
        }

        public async Task<IEnumerable<Music>> GetMusicsLibrary()
        {
            string query = $@"  SELECT 
                                    ID {nameof(Music.Id)},
                                    NAME {nameof(Music.Name)}, 
                                    SINGER {nameof(Music.SingerName)}, 
                                    RELEASE_DATE {nameof(Music.ReleasDate)},
                                    ATIVO {nameof(Music.Ativo)}
                                FROM dbo.TB_MUSIC";
        
            return await Connection.QueryAsync<Music>(query);
        }

        public async Task<int> PostMusicLibrary(Music music)
        {
            string query = "INSERT INTO dbo.TB_MUSIC (NAME, SINGER, RELEASE_DATE) VALUES (@name, @singer, @date)";

            var parameters = new DynamicParameters();
            parameters.Add("name", music.Name);
            parameters.Add("singer", music.SingerName);
            parameters.Add("date", music.ReleasDate);

            return await Connection.ExecuteAsync(query, parameters);
        }
    }
}