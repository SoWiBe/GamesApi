using Calabonga.OperationResults;
using GamesApi.Web.Definitions.Base;
using GamesApi.Web.Definitions.MongoDb.Models;
using GamesApi.Web.Endpoints.UsersEndpoints.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace GamesApi.Web.Endpoints.GamesEndpoints
{
    public class UsersEndpoint : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment env)
        {
            app.MapGet("/api/get-user/{id}/{game}", GetUserInfo);
            app.MapPost("/api/add-user", PostUserInfo);
            app.MapPut("/api/update-user/", UpdateUserInfo);
            app.UseCors("CorsPolicy");

        }
          
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Users")]
        private async Task<OperationResult<int>> GetUserInfo([FromServices] IMediator mediator, HttpContext context, string id, int game)
           => await mediator.Send(new GetUserRequest(id,game), context.RequestAborted);

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Users")]
        private async Task<OperationResult<UserModel>> PostUserInfo([FromServices] IMediator mediator, HttpContext context, UserModel user)
            => await mediator.Send(new PostUserRequest(user), context.RequestAborted);

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Users")]
        private async Task<OperationResult<string>> UpdateUserInfo([FromServices] IMediator mediator, HttpContext context, PutModel user)
            => await mediator.Send(new PutUserRequest(user), context.RequestAborted);
    }
}
