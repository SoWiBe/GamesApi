using MongoDB.Bson.Serialization.Attributes;

namespace GamesApi.Web.Definitions.MongoDb.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonIgnoreIfNull]
        public string Id { get; set; }

        [BsonElement("game")]
        public string Game { get; set; }
        [BsonElement("level")]
        public string Level { get; set; }
    }
}
