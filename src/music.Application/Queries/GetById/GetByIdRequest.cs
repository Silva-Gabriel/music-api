using MediatR;

namespace music.Application.Queries.GetById
{
    public class GetByIdRequest : IRequest<GetByIdResponse>
    {
        public long Id { get; set; }
    }
}