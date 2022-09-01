using AutoMapper;
using Calabonga.OperationResults;
using GamesApi.Domain.Base;
using GamesApi.Web.Definitions.MongoDb.Models;
using MediatR;

namespace GamesApi.Web.Endpoints.UsersEndpoints.Queries
{
    public record PutUserRequest(PutModel user) : IRequest<OperationResult<string>>;

    public class PutUserRequestHandler : IRequestHandler<PutUserRequest, OperationResult<string>>
    {
        private readonly IMapper _mapper;
        private readonly IDbWorker<UserModel> _repository;

        public PutUserRequestHandler(IMapper mapper, IDbWorker<UserModel> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<OperationResult<string>> Handle(PutUserRequest request, CancellationToken cancellationToken)
        {
            var record = _repository.GetRecordsByFilter(x => x.Id == request.user.Id);
            record.Result.Result.Games[request.user.Game].Level = request.user.Level;
            try
            {
                await _repository.UpdateRecord(record.Result.Result);
            }
            catch (Exception ex)
            {
                return new OperationResult<string> { Exception = ex };
            }

            return new OperationResult<string> { Result = "User was successfully added!" };
        }
    }

}
