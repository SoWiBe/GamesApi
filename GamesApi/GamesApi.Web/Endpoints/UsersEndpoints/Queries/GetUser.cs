using AutoMapper;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using GamesApi.Domain.Base;
using GamesApi.Web.Definitions.MongoDb.Models;
using MediatR;

namespace GamesApi.Web.Endpoints.UsersEndpoints.Queries
{
    public record GetUserRequest(Guid id) : IRequest<OperationResult<UserModel>>;

    public class GetUserRequestHandler : RequestHandler<GetUserRequest, OperationResult<UserModel>>
    {
        private readonly IMapper _mapper;
        private readonly IDbWorker<UserModel> _repository;

        public GetUserRequestHandler(IMapper mapper, IDbWorker<UserModel> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        protected override async Task<OperationResult<UserModel>> Handle(GetUserRequest request)
        {
            var id = request.id;
            var operation = OperationResult.CreateResult<UserModel>();

            var userFromDb = await _repository.GetRecordsByFilter(x => new Guid(x.Id) == id);
            operation.Result = userFromDb.First();
            return operation;
        }
    }
}
