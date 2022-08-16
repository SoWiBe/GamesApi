using MediatR;

namespace GamesApi.Web.Endpoints.UsersEndpoints.Queries
{
    public record GetUserRequest : IRequest<string>;

    public class GetUserRequestHandler : RequestHandler<GetUserRequest, string>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public GetUserRequestHandler(IHttpContextAccessor contextAccessor) => _contextAccessor = contextAccessor;

        protected override string Handle(GetUserRequest request)
        {
            var user = 
        }
    }
}
