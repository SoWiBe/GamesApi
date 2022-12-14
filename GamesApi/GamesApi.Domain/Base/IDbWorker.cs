using Calabonga.OperationResults;
namespace GamesApi.Domain.Base
{
    public interface IDbWorker<T>
    {
        Task<OperationResult<T>> GetRecordsByFilter(Func<T, bool> predicate);
        Task<OperationResult<bool>> AddNewRecord(T record);
        Task<OperationResult<bool>> AddNewRecordsRange(IEnumerable<T> records);
        Task<OperationResult<bool>> UpdateRecord(T record);
    }
}
