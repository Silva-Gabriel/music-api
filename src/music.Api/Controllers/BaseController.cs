using MediatR;

namespace music.Api.Controllers
{
    public class BaseController
    {
        protected readonly IMediator Mediator; 

        public BaseController(IMediator mediator) => Mediator = mediator;
    }
}