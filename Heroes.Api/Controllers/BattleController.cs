using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes.Infrastructure;
using Heroes.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Heroes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattleController : ControllerBase
    {
        private readonly IBattleRepository _battleRepository;
        public BattleController(IBattleRepository battleRepository)
        {
            _battleRepository = battleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostBattle(Battle battle)
        {
            await _battleRepository.InsertAsync(battle);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetBattleHistory()
        {
            var battles = await _battleRepository.GetBattlesAsync();
            return Ok(battles);
        }
    }
}