using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes.Infrastructure.Models;
using MongoDB.Driver;

namespace Heroes.Infrastructure
{
    public class BattleRepository : IBattleRepository
    {
        private readonly IMongoCollection<Battle> _mongoCollection;
        public BattleRepository(IMongoCollection<Battle> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task<IEnumerable<Battle>> GetBattlesAsync()
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public async Task InsertAsync(Battle battle)
        {
            await _mongoCollection.InsertOneAsync(battle);
        }
    }
}