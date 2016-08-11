using strange.extensions.context.impl;

namespace Assets.strangerocks.game
{
    public class GameRoot:ContextView
    {

        void Start()
        {
            context = new GameContext(this);
        }
    }
}
