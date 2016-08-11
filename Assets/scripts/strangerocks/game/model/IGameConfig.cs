using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.strangerocks.game
{
    public interface IGameConfig
    {
        int initLives { get; set; }
        int newLifeEvery { get; set; }
        int maxLives { get; set; }
        int initRocks { get; set; }
        int additionalRocksPerLevel { get; set; }
        int baseRockScore { get; set; }
        float rockExplosiveForceMin { get; set; }
        float rockExplosiveForceMax { get; set; }
        float rockExplosiveForceRadius { get; set; }
        float enemySpawnSecondsMin { get; set; }
        float enemySpawnSecondsMax { get; set; }
        int baseEnemyScore { get; set; }
    }
}
