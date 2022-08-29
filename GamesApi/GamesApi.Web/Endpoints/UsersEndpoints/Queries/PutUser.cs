using AutoMapper;
using Calabonga.OperationResults;
using GamesApi.Domain.Base;
using GamesApi.Web.Definitions.MongoDb.Models;
using MediatR;

namespace GamesApi.Web.Endpoints.UsersEndpoints.Queries
{
    public record PutUserRequest(UserModel model) : IRequest<string>;

    public class PutUserRequestHandler : IRequestHandler<PutUserRequest, string>
    {
        private readonly IMapper _mapper;
        private readonly IDbWorker<UserModel> _repository;

        public PutUserRequestHandler(IMapper mapper, IDbWorker<UserModel> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<string> Handle(PutUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddNewRecord(request.model);
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }

            return "Success!";
        }
    }

}
