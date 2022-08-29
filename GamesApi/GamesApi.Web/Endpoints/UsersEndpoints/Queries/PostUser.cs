using AutoMapper;
using Calabonga.OperationResults;
using GamesApi.Domain.Base;
using GamesApi.Web.Definitions.MongoDb.Models;
using MediatR;

namespace GamesApi.Web.Endpoints.UsersEndpoints.Queries
{
    public record PostUserRequest(UserModel user) : IRequest<OperationResult<UserModel>>;

    public class PostUserRequestHandler : IRequestHandler<PostUserRequest, OperationResult<UserModel>>
    {
        private readonly IMapper _mapper;
        private readonly IDbWorker<UserModel> _repository;

        public PostUserRequestHandler(IMapper mapper, IDbWorker<UserModel> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<OperationResult<UserModel>> Handle(PostUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.UpdateRecord(request.user);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OperationResult<UserModel> { Exception = ex });
            }

            return Task.FromResult(new OperationResult<UserModel> { Result = new UserModel { Id = request.user.Id, Games = request.user.Games } });
        }
    }
}
