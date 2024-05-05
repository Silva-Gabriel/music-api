using MediatR;
using music.Domain.Repository;

namespace music.Application.Music
{
    public class MusicHandler : IRequestHandler<MusicRequest, MusicResponse>
    {
        private readonly IMusicRepository Repository;

        public MusicHandler(IMusicRepository repository)
        {
            Repository = repository;
        }

        public async Task<MusicResponse> Handle(MusicRequest request, CancellationToken cancellationToken)
        {
            var repository = await Repository.GetMusicsLibrary();
            var result = new MusicResponse
            {
                Musics = repository
            };
            
            return result;
        }
    }
}