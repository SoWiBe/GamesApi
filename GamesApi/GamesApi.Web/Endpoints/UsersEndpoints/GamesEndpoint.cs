using GamesApi.Web.Definitions.Base;
using GamesApi.Web.Endpoints.GamesEndpoints.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace GamesApi.Web.Endpoints.GamesEndpoints
{
    public class GamesEndpoint : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment env) => app.MapGet("/api/get-users", GetUsers);

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Users")]
        private async Task<string> GetUsers([FromServices] IMediator mediator, HttpContext context)
            => await mediator.Send(new GetUsersRequest(), context.RequestAborted);
    }
}
