using MediatR;
using music.Domain.Models.Response;
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
            var result = await Repository.PostMusicLibrary(new Domain.Models.Music
            {
                Name = request.Name,
                SingerName = request.SingerName,
                StyleId = request.StyleId,
                ReleaseDate = request.ReleaseDate
            });

            if(result <= 0)
            {
                return ApiResponse.ErrorResponse<CreateMusicResponse>(System.Net.HttpStatusCode.InternalServerError, "0002", "Não foi possível criar a música");
            }

            return ApiResponse.CreatedResponse<CreateMusicResponse>();
        }
    }
}