using Calabonga.OperationResults;
using GamesApi.Web.Definitions.Base;
using GamesApi.Web.Definitions.MongoDb.Models;
using GamesApi.Web.Endpoints.GamesEndpoints.Queries;
using GamesApi.Web.Endpoints.UsersEndpoints.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace GamesApi.Web.Endpoints.GamesEndpoints
{
    public class UsersEndpoint : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment env)
        {
            app.MapGet("/api/get-users", GetUsers);
            app.MapGet("/api/get-user/{id}", GetUserInfo);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Users")]
        private async Task<string> GetUsers([FromServices] IMediator mediator, HttpContext context)
            => await mediator.Send(new GetUsersRequest(), context.RequestAborted);
          
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Users")]
        private async Task<OperationResult<UserModel>> GetUserInfo([FromServices] IMediator mediator, HttpContext context, Guid id)
           => await mediator.Send(new GetUserRequest(id), context.RequestAborted);
    }
}
