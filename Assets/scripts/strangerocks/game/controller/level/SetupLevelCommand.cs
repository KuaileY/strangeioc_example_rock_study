using strange.extensions.command.impl;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class SetupLevelCommand:Command
    {
        [Inject(GameElement.GAME_FIELD)]
        public GameObject gameField { get; set; }
        [Inject]
        public CreatePlayerSignal createPlayerSignal { get; set; }
        [Inject]
        public CreateRockSignal createRockSignal { get; set; }
        [Inject]
        public CreateTestSignal createTestSignal { get; set; }
        [Inject]
        public IGameConfig gameConfig { get; set; }
        [Inject]
        public IGameModel gameModel { get; set; }
        public override void Execute()
        {
            createPlayerSignal.Dispatch();

            int rocks = ((gameModel.level - 1)*gameConfig.additionalRocksPerLevel) + gameConfig.initRocks;
            for (int i = 0; i < rocks; i++)
            {
                float theta = UnityEngine.Random.Range(0, Mathf.PI*2);
                float x = Mathf.Cos(theta)*3f;
                float y = Mathf.Sin(theta)*3f;
                Vector2 randomPos = new Vector2(x, y);

                createRockSignal.Dispatch(1, randomPos);
            }
        }
    }
}
