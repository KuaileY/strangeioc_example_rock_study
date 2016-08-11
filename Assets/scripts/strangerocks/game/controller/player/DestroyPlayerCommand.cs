using System.Collections;
using strange.extensions.command.impl;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class DestroyPlayerCommand:Command
    {
        [Inject]
        public ShipView shipView { get; set; }
        [Inject]
        public GameEndSignal gameEndSignal { get; set; }
        [Inject]
        public IGameModel gameModel { get; set; }
        [Inject]
        public bool isEndOfLevel { get; set; }
        [Inject]
        public UpdateLivesSignal updateLivesSignal { get; set; }
        [Inject]
        public IRoutineRunner routineRunner { get; set; }
        [Inject]
        public CreatePlayerSignal createPlayerSiganal { get; set; }
        public override void Execute()
        {
            if (!gameModel.levelInProgress) return;
            if (!isEndOfLevel)
            {
                gameModel.levelInProgress = false;

                gameModel.lives--;
                updateLivesSignal.Dispatch(gameModel.lives);

                if (gameModel.lives <= 0)
                    gameEndSignal.Dispatch();
                else
                {
                    Retain();
                    routineRunner.StartCoroutine(waitThenCreatShip());
                }   
            }
            GameObject.Destroy(shipView.gameObject);
            if (injectionBinder.GetBinding<ShipView>(GameElement.PLAYER_SHIP) != null)
                injectionBinder.Unbind<ShipView>(GameElement.PLAYER_SHIP);
        }

        private IEnumerator waitThenCreatShip()
        {
            yield return new WaitForSeconds(2f);
            createPlayerSiganal.Dispatch();
            Release();
        }
    }
}
