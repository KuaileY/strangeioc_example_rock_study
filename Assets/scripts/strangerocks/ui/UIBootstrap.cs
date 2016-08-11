using strange.extensions.context.impl;

namespace Assets.strangerocks.ui
{
    public class UIBootstrap:ContextView
    {
        void Awake()
        {
            context = new UIContext(this);
        }
    }
}
