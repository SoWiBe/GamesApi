using AutoMapper;
using Calabonga.OperationResults;
using GamesApi.Domain.Base;
using GamesApi.Web.Definitions.MongoDb.Models;
using MediatR;

namespace GamesApi.Web.Endpoints.UsersEndpoints.Queries
{
    public record PutUserRequest(int game,int level) : IRequest<int>;

    public class PutUserRequestHandler : IRequestHandler<PutUserRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IDbWorker<UserModel> _repository;

        public PutUserRequestHandler(IMapper mapper, IDbWorker<UserModel> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(PutUserRequest request, CancellationToken cancellationToken)
        {
            var record = _repository.GetRecordsByFilter(id);
            record.Result.Result.Games[request.game].Level = request.level;
            try
            {
                await _repository.UpdateRecord(record.Result.Result);
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 0;
        }
    }

}
