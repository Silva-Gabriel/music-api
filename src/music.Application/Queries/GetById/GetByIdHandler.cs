
using System.Dynamic;
using System.Net;
using MediatR;
using Microsoft.Extensions.Logging;
using music.Domain.Models.Response;
using music.Domain.Repository;

namespace music.Application.Queries.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdRequest, GetByIdResponse>
    {
        private readonly IMusicRepository Repository;
        private readonly ILogger<GetByIdHandler> Logger;

        public GetByIdHandler(IMusicRepository Repository, ILogger<GetByIdHandler> Logger)
        {
            this.Repository = Repository;
            this.Logger = Logger;
        }

        public async Task<GetByIdResponse> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var music = await Repository.GetMusicById(request.Id);

                if(music == null)
                {
                    return ApiResponse.ErrorResponse<GetByIdResponse>(HttpStatusCode.NotFound, "0003", "Música não encontrada na biblioteca");
                }

                return ApiResponse.OkResponse<GetByIdResponse>(music);
            }
            catch(Exception ex)
            {
                Logger.LogError("[GetByIdHandler] Error Ocurred: " + ex.Message);
                return ApiResponse.ErrorResponse<GetByIdResponse>(HttpStatusCode.InternalServerError, "0001", "Erro ao buscar registro");
            }
        }
    }
}