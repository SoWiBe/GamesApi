using GamesApi.Infrastructure.MongoDb;
using MongoDB.Bson.Serialization.Attributes;

namespace GamesApi.Web.Definitions.MongoDb.Models
{
    public class UserModel : IMongoModel
    {
        [BsonId]
        [BsonIgnoreIfNull]
        public string Id { get; set; }
        [BsonElement("Levels")]
        public IList<GameModel> Games { get; set; } = new List<GameModel>();
    }
}
