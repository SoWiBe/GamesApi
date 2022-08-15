using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApi.Infrastructure.MongoDb
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DbName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}
