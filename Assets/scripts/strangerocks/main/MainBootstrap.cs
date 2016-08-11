using strange.extensions.context.impl;

namespace Assets.strangerocks.main
{
    public class MainBootstrap : ContextView
    {

        void Awake()
        {
            context = new MainContext(this);
        }
    
	}

}
