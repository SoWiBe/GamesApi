using GamesApi.Domain.Base;
using GamesApi.Infrastructure.MongoDb;
using GamesApi.Infrastructure.MongoDb.Context;
using GamesApi.Web.Definitions.Base;
using GamesApi.Web.Definitions.MongoDb.Models;
using MongoDB.Driver;

namespace GamesApi.Web.Definitions.MongoDb
{
    public class MongoDefinition : AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("mongo");

            services.AddTransient<IMongoClient>(provider => new MongoClient(connectionString));

            services.AddSingleton<IDbWorker<UserModel>>(provider =>
            {
                var client = provider.GetRequiredService<IMongoClient>();
                var settings = new MongoDbSettings()
                {
                    ConnectionString = connectionString,
                    CollectionName = configuration["Users:Collection"],
                    DbName = configuration["Users:Database"]
                };
                var logger = provider.GetRequiredService<ILogger<MongoDbWorker<UserModel>>>();
                return new MongoDbWorker<UserModel>(client, settings, logger);
            });
        }
    }
}
