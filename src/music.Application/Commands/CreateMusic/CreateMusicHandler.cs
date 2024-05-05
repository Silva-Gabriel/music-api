using MediatR;
using music.Domain.Repository;

namespace music.Application.Commands.CreateMusic
{
    public class CreateMusicHandler : IRequestHandler<CreateMusicRequest, CreateMusicResponse>
    {
        private readonly IMusicRepository Repository;

        public CreateMusicHandler(IMusicRepository repository)
        {
            Repository = repository;
        }
        
        public async Task<CreateMusicResponse> Handle(CreateMusicRequest request, CancellationToken cancellationToken)
        {
            var response = new Domain.Models.Music
            {
                Name = request.Name,
                SingerName = request.SingerName,
                ReleasDate = request.ReleasDate
            };

            await Repository.PostMusicLibrary(response);
            return await Task.FromResult(new CreateMusicResponse());
        }
    }
}