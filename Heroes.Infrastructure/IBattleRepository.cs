using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes.Infrastructure.Models;

namespace Heroes.Infrastructure
{
    public interface IBattleRepository
    {
        Task<IEnumerable<Battle>> GetBattlesAsync();
        Task InsertAsync(Battle battle);
    }
}