using AutoMapper;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using GamesApi.Domain.Base;
using GamesApi.Web.Definitions.MongoDb.Models;
using MediatR;

namespace GamesApi.Web.Endpoints.UsersEndpoints.Queries
{
    public record GetUserRequest(int id, string game) : IRequest<string>;

    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, string>
    {
        private readonly IMapper _mapper;
        private readonly IDbWorker<UserModel> _repository;

        public GetUserRequestHandler(IMapper mapper, IDbWorker<UserModel> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<string> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            UserModel result = new UserModel();
            GameModel level = new GameModel();

            for (int i = 1; i <= 11; i++) {
                result.Games.Add(new GameModel { Level = "1" });
            }

            var id = request.id;
            var game = request.game;

            if(id == null)
            {
                return "no id";
            }

            result.Id = id.ToString();
            
            try
            {
                var userFromDb = _repository.GetRecordsByFilter(x => Convert.ToInt32(x.Id) == id);
                
                if (userFromDb.Result.FirstOrDefault() == null)
                {
                    _repository.AddNewRecord(result);
                }
                else
                {
                    result = userFromDb.Result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }


            return result.Games[Convert.ToInt32(game)].Level;
        }
    }
}
