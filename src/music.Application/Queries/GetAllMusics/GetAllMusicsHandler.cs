using MediatR;
using music.Domain.Models.Response;
using music.Domain.Repository;

namespace music.Application.Music
{
    public class GetAllMusicsHandler : IRequestHandler<GetAllMusicsRequest, GetAllMusicsResponse>
    {
        private readonly IMusicRepository Repository;

        public GetAllMusicsHandler(IMusicRepository repository)
        {
            Repository = repository;
        }

        public async Task<GetAllMusicsResponse> Handle(GetAllMusicsRequest request, CancellationToken cancellationToken)
        {
            var musics = await Repository.GetMusicsLibrary();
            if(musics == null)
            {
                return ApiResponse.OkResponse<GetAllMusicsResponse>();
            }

            return ApiResponse.OkResponse<GetAllMusicsResponse>(musics);
        }
    }
}