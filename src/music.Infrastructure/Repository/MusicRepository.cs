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

        public async Task<Music> GetMusicById(long id)
        {
            var parameter = new DynamicParameters();

            string query = @$"  SELECT 
                                    ID {nameof(Music.Id)},
                                    NAME {nameof(Music.Name)},
                                    SINGER {nameof(Music.SingerName)},
                                    STYLE_ID {nameof(Music.StyleId)},
                                    RELEASE_DATE {nameof(Music.ReleaseDate)},
                                    CASE
                                        WHEN ACTIVE = '1' THEN 1
                                        ELSE 0
                                    END {nameof(Music.Active)}
                                FROM dbo.TB_MUSIC
                                WHERE ID = @id";

            parameter.Add("id", id);

            return await Connection.QueryFirstOrDefaultAsync<Music>(query, parameter);
        }

        public async Task<IEnumerable<Music>> GetMusicsLibrary()
        {
            string query = $@"  SELECT 
                                    ID {nameof(Music.Id)},
                                    NAME {nameof(Music.Name)}, 
                                    SINGER {nameof(Music.SingerName)}, 
                                    RELEASE_DATE {nameof(Music.ReleaseDate)},
                                     STYLE_ID {nameof(Music.StyleId)},
                                    CASE
                                        WHEN ACTIVE = '1' THEN 1
                                        ELSE 0
                                    END {nameof(Music.Active)}
                                FROM dbo.TB_MUSIC";

            return await Connection.QueryAsync<Music>(query);
        }

        public async Task<int> PostMusicLibrary(Music music)
        {
            string query = $@"  INSERT INTO dbo.TB_MUSIC 
                                    (NAME, SINGER, RELEASE_DATE, STYLE_ID) 
                                VALUES 
                                    (@name, @singer, @date, @styleId)";

            var parameters = new DynamicParameters();
            parameters.Add("name", music.Name);
            parameters.Add("singer", music.SingerName);
            parameters.Add("date", music.ReleaseDate);
            parameters.Add("styleId", music.StyleId);

            return await Connection.ExecuteAsync(query, parameters);
        }
    }
}