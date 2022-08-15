using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApi.Infrastructure.MongoDb.Context
{
    //// <typeparam name="T">Model type</typeparam>
    public class MongoDbContext<T> : IMongoDbContext<T>
    {
        private readonly IMongoCollection<T> _collection;
        public MongoDbContext(MongoDbSettings settings, IMongoClient client) =>
            _collection = client.GetDatabase(settings.DbName).GetCollection<T>(settings.CollectionName);

        public IMongoCollection<T> GetCollection() => _collection;
        public IEnumerator<T> GetEnumerator() => _collection.AsQueryable().AsEnumerable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
