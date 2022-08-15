using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using GamesApi.Web.Definitions.Mediator.Base;
using GamesApi.Web.Endpoints.EventItemsEndpoints.ViewModels;
using MediatR;

namespace GamesApi.Web.Definitions.Mediator
{
    public class LogPostTransactionBehavior : TransactionBehavior<IRequest<OperationResult<EventItemViewModel>>, OperationResult<EventItemViewModel>>
    {
        public LogPostTransactionBehavior(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}