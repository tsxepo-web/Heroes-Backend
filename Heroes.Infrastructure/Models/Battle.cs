using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Heroes.Infrastructure.Models
{
    public class Battle
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string HeroName { get; set; } = string.Empty;
        public string VillainName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime BattleTime { get; set; }
        public int HeroScore { get; set; }
        public int VillainScore { get; set; }
    }
}