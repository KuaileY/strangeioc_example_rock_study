using System;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class CreateGameFieldCommand:Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }
        public override void Execute()
        {
            Vector2 center = Vector2.zero;

            if (injectionBinder.GetBinding<GameObject>(GameElement.GAME_FIELD) == null)
            {
                GameObject gameField = new GameObject(GameElement.GAME_FIELD.ToString());
                gameField.transform.localPosition = center;
                gameField.transform.SetParent(contextView.transform);

                injectionBinder.Bind<GameObject>().ToValue(gameField).ToName(GameElement.GAME_FIELD);
            }
        }
    }
}
