using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApi.Infrastructure.MongoDb.Context
{
    public interface IMongoDbContext<T> : IDbContext<T>
    {
        IMongoCollection<T> GetCollection();
    }
}
