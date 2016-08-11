using strange.extensions.command.impl;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class CreatePlayerCommand:Command
    {
        [Inject(GameElement.GAME_FIELD)]
        public GameObject gameField { get; set; }
        [Inject]
        public IGameModel gameModel { get; set; }
        public override void Execute()
        {
            if (injectionBinder.GetBinding<ShipView>(GameElement.PLAYER_SHIP) != null)
                injectionBinder.Unbind<ShipView>(GameElement.PLAYER_SHIP);

            GameObject shipStyle = Resources.Load<GameObject>(GameElement.PLAYER_SHIP.ToString());
            shipStyle.transform.localScale = Vector2.one;

            GameObject shipGo = GameObject.Instantiate(shipStyle) as GameObject;
            shipGo.transform.localPosition = Vector2.zero;
            shipGo.layer = LayerMask.NameToLayer(MaskLayers.PLAYER.ToString());

            shipGo.transform.SetParent(gameField.transform);
            injectionBinder.Bind<ShipView>().ToValue(shipGo.GetComponent<ShipView>()).ToName(GameElement.PLAYER_SHIP);

            gameModel.levelInProgress = true;
        }
    }
}
