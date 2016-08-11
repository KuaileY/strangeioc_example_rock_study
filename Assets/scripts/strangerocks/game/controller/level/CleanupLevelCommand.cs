
using strange.extensions.command.impl;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class CleanupLevelCommand:Command
    {
        [Inject(GameElement.GAME_FIELD)]
        public GameObject gameField { get; set; }
        [Inject]
        public DestroyPlayerSignal destroyPlayerSignal { get; set; }
        [Inject]
        public DestroyRockSignal destroyRockSignal { get; set; }
        public override void Execute()
        {
            TestLoadConfig.log.Trace("CleanupLevelCommand Execute");
            if (injectionBinder.GetBinding<ShipView>(GameElement.PLAYER_SHIP) != null)
            {
                ShipView shipView = injectionBinder.GetInstance<ShipView>(GameElement.PLAYER_SHIP);
                destroyPlayerSignal.Dispatch(shipView, true);
            }

            RockView[] rocks = gameField.GetComponentsInChildren<RockView>();
            TestLoadConfig.log.Debug(rocks.Length);
            foreach (RockView rock in rocks)
            {
                destroyRockSignal.Dispatch(rock, false);
            }
        }
    }
}
