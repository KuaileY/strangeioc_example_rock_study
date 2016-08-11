
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class GameIndependStartCommand:Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView{get;set;}
        public override void Execute()
        {
            GameObject go = new GameObject("debug_view");
            go.AddComponent<GameDebugView>();
            go.transform.SetParent(contextView.transform);
        }
    }
}
