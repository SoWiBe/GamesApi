﻿using Calabonga.Microservices.Core;
using MediatR;
using System.Security.Claims;

namespace GamesApi.Web.Endpoints.GamesEndpoints.Queries
{
    public record GetUsersRequest : IRequest<string>;

    public class GetUsersRequestHandler : RequestHandler<GetUsersRequest, string>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public GetUsersRequestHandler(IHttpContextAccessor contextAccessor) => _contextAccessor = contextAccessor;

        protected override string Handle(GetUsersRequest request)
        {
            var users = ClaimsHelper.GetValues<string>((ClaimsIdentity)user.Identity!, ClaimTypes.Role);
            return users;
        }
    }
}