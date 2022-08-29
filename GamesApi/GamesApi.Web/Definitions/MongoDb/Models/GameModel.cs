using MongoDB.Bson.Serialization.Attributes;

namespace GamesApi.Web.Definitions.MongoDb.Models
{
    public class GameModel
    {
        
        [BsonElement("level")]
        public string Level { get; set; }
    }
}
