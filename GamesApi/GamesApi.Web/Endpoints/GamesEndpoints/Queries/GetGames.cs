using Calabonga.Microservices.Core;
using MediatR;
using System.Security.Claims;

namespace GamesApi.Web.Endpoints.GamesEndpoints.Queries
{
    public record GetGamesRequest : IRequest<string>;

    public class GetGamesRequestHandler : RequestHandler<GetGamesRequest, string>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public GetGamesRequestHandler(IHttpContextAccessor contextAccessor) => _contextAccessor = contextAccessor;

        protected override string Handle(GetGamesRequest request)
        {
            var user = _contextAccessor.HttpContext!.User;
            var games = ClaimsHelper.GetValues<string>((ClaimsIdentity)user.Identity!, ClaimTypes.Role);
            return
        }
    }
}
