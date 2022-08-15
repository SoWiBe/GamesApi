using Calabonga.OperationResults;
using GamesApi.Infrastructure.MongoDb.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApi.Infrastructure.MongoDb
{
    internal class MongoDbWorker<T> : IDbWorker<T>
    {
        private readonly ILogger<MongoDbWorker<T>> _logger;
        private readonly IMongoDbContext<T> _context;

        public MongoDbWorker(ILogger<MongoDbWorker<T>> logger, IMongoDbContext<T> context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<OperationResult<bool>> AddNewRecord(T record)
        {
            OperationResult<bool> result = new OperationResult<bool>();
            try
            {
                await _context.GetCollection().InsertOneAsync(record);
                result.Result = true;
            } 
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                result.Result = false;
                result.AddError(e.Message);
            }
            return result;
        }
        public async Task<OperationResult<bool>> AddNewRecordsRange(IEnumerable<T> records)
        {
            OperationResult<bool> result = new OperationResult<bool>();
            try
            {
                await _context.GetCollection().InsertManyAsync(records);
                result.Result = true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                result.Result = false;
                result.AddError(e.Message);
            }
            return result;
        }

        public Task<IEnumerable<T>> GetAllRecords()
        {
            return Task.FromResult<IEnumerable<T>>(_context);
        }
        public Task<IEnumerable<T>> GetRecordsByFilter(Func<T, bool> predicate)
        {
            var result = _context.Where(predicate);
            return Task.FromResult(result);
        }
    }
}
