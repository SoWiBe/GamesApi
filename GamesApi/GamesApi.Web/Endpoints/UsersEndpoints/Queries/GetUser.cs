using AutoMapper;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using GamesApi.Domain.Base;
using GamesApi.Web.Definitions.MongoDb.Models;
using MediatR;

namespace GamesApi.Web.Endpoints.UsersEndpoints.Queries
{
    public record GetUserRequest(GetModel user) : IRequest<OperationResult<int>>;

    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, OperationResult<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDbWorker<UserModel> _repository;

        public GetUserRequestHandler(IMapper mapper, IDbWorker<UserModel> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
         
        public async Task<OperationResult<int>> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            UserModel result = new UserModel();
            GameModel level = new GameModel();

            for (int i = 1; i <= 11; i++) {
                result.Games.Add(new GameModel { Level = 1 });
            }

            var id = request.user.Id;
            var game = request.user.Game;

            if(id == null)
            {
                return new OperationResult<int> { Exception = new Exception("No id") };
            }

            result.Id = id;
            
            try
            {
                var userFromDb = _repository.GetRecordsByFilter(x => x.Id == result.Id);
                
                if (userFromDb.Result.Result == null)
                {
                    await _repository.AddNewRecord(result);
                }
                else
                {
                    result = userFromDb.Result.Result;
                }
            }
            catch (Exception ex)
            {
                return new OperationResult<int> { Exception = ex };
            }


            return new OperationResult<int> { Result = result.Games[request.user.Game].Level };
        }
    }
}
