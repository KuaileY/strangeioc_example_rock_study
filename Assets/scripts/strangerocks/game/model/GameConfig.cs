using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class GameConfig:IGameConfig
    {
        [PostConstruct]
        public void PostConstruct()
        {
            TextAsset file = Resources.Load("gameConfig") as TextAsset;
            var n = SimpleJSON.JSON.Parse(file.text);
            initLives = n["initLives"].AsInt;
            newLifeEvery = n["newLifeEvery"].AsInt;
            maxLives = n["maxLives"].AsInt;
            initRocks = n["initRocks"].AsInt;
            additionalRocksPerLevel = n["additionalRocksPerLevel"].AsInt;
            baseRockScore = n["baseRockScore"].AsInt;
            rockExplosiveForceMin = n["rockExplosiveForceMin"].AsFloat;
            rockExplosiveForceMax = n["rockExplosiveForceMax"].AsFloat;
            rockExplosiveForceRadius = n["rockExplosiveForceRadius"].AsInt;

            enemySpawnSecondsMin = n["enemySpawnSecondsMin"].AsFloat;
            enemySpawnSecondsMax = n["enemySpawnSecondsMax"].AsFloat;
            baseEnemyScore = n["baseEnemyScore"].AsInt;
        }

        #region implement IGameConfig
        public int initLives { get; set; }
        public int newLifeEvery { get; set; }
        public int maxLives { get; set; }
        public int initRocks { get; set; }
        public int additionalRocksPerLevel { get; set; }
        public int baseRockScore { get; set; }
        public float rockExplosiveForceMin { get; set; }
        public float rockExplosiveForceMax { get; set; }
        public float rockExplosiveForceRadius { get; set; }
        public float enemySpawnSecondsMin { get; set; }
        public float enemySpawnSecondsMax { get; set; }
        public int baseEnemyScore { get; set; }
        #endregion
    }
}
